using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using Website.Server.Extensions;
using Website.Server.Models;
using Website.Shared.Models;

namespace Website.Server.Services;

public abstract class BaseDatabaseService<TData> where TData : IDatabaseObject
{
    protected readonly IMongoCollection<TData> collection;
    protected readonly IMongoDatabase mongoDatabase;
    protected readonly MongoClient mongoClient;
    
    protected readonly IMapper _mapper;
    protected readonly ReplaceOptions upsert = new () { IsUpsert = true };

    protected BaseDatabaseService(string name, IOptions<RadiumDatabaseSettings> dbSettings, IMapper _mapper)
    {
        this._mapper = _mapper;
        
        mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
        mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);
        collection = mongoDatabase.GetCollection<TData>(name);

        Task.Run(CreateIndexes);
    }
    
    /// <summary>
    /// Initializes indexes with MongoDB. Defaults to a unique "Name" index.
    /// </summary> 
    protected virtual async Task CreateIndexes()
    {
        var keys = Builders<TData>.IndexKeys;
        var indexModel = new CreateIndexModel<TData>(keys.Text("Name"), new CreateIndexOptions() { Unique = true });

        await collection.Indexes.CreateOneAsync(indexModel);
    }

    /// <summary>
    /// Gets every item in the database, transformed to a DTO if requested.
    /// </summary> 
    public virtual async Task<List<TDTO>?> GetAllAsync<TDTO>() where TDTO : IDTO
    {
        return await collection
            .Find(_ => true)
            .Project(doc => doc.ToDTO<TDTO>(_mapper))
            .ToListAsync();
    }
    
    /// <summary>
    /// Gets a single item by name via IDatabaseObject
    /// </summary> 
    public virtual async Task<TDTO?> GetByNameAsync<TDTO>(string? name) where TDTO : IDTO
    {
        if (name == null)
            return default;
        
        var doc = await collection.Find(x => x.Name == name).FirstOrDefaultAsync();
        if (doc == null)
            return default;
            
        return doc.ToDTO<TDTO>(_mapper);
    }
    
    protected virtual async Task<TData> GetByNameAsync(string? name)
    {
        if (name == null)
            return default;
        
        return await collection.Find(x => x.Name == name).FirstOrDefaultAsync();
    }
    
    /// <summary>
    /// Gets a single item by filter
    /// </summary> 
    public virtual async Task<TDTO?> GetByFilterAsync<TDTO>(FilterDefinition<TData> filter) where TDTO : IDTO
    {
        if (filter == null) throw new ArgumentNullException(nameof(filter));
        
        var doc = await collection.Find(filter).FirstOrDefaultAsync();
        if (doc == null)
            return default;
            
        return doc.ToDTO<TDTO>(_mapper);
    }
    
    /// <summary>
    /// Queries for a list of items matching a search
    /// </summary> 
    public virtual async Task<List<TDTO>?> QueryAsync<TDTO>(FilterDefinition<TData> filter) where TDTO : IDTO
    {
        if (filter == null) throw new ArgumentNullException(nameof(filter));
        return await collection.Find(filter)
            .Project(doc => doc.ToDTO<TDTO>(_mapper))
            .ToListAsync();
    }
    
    /// <summary>
    /// Creates a new object, optionally from a DTO
    /// </summary> 
    public virtual async Task CreateAsync<TDTO>(TDTO newDoc)  where TDTO : IDTO
    {
        TData doc = MapFromDTO(newDoc);
        await collection.InsertOneAsync(doc);
    }
    
    public virtual async Task CreateAsync(TData newDoc)
    {
        await collection.InsertOneAsync(newDoc);
    }
    
    /// <summary>
    /// Updates/Upserts an object, optionally from a DTO
    /// </summary> 
    public virtual async Task UpdateAsync<TDTO>(TDTO updatedDoc, FilterDefinition<TData>? filter = null)  where TDTO : IDTO
    {
        TData doc = MapFromDTO(updatedDoc);
        filter ??= new FilterDefinitionBuilder<TData>().Where(x => x.Name == doc.Name);
        
        await collection.ReplaceOneAsync(filter, doc, upsert);
    }
    
    protected virtual async Task UpdateAsync(TData doc, FilterDefinition<TData>? filter = null)
    {
        filter ??= new FilterDefinitionBuilder<TData>().Where(x => x.Name == doc.Name);
        await collection.ReplaceOneAsync(filter, doc, upsert);
    }
    
    /// <summary>
    /// Removes by name via IDatabaseObject
    /// </summary> 
    public virtual async Task RemoveByNameAsync(string Name)
    {
        await collection.DeleteOneAsync(x => x.Name == Name);
    }
    
    /// <summary>
    /// Removes all objects matching a filter
    /// </summary> 
    public virtual async Task RemoveAllAsync(FilterDefinition<TData>? filter = null)
    {
        await collection.DeleteManyAsync(filter);
    }

    
    /// <summary>
    /// DTO transformation function
    /// </summary> 
    protected virtual TData MapFromDTO<TDTO>(TDTO obj) where TDTO : IDTO
    {
        return _mapper.Map<TData>(obj);
    }

}