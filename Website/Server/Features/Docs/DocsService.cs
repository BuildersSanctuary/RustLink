using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Driver;
using Website.Server.Extensions;
using Website.Server.Models;
using Website.Shared.Models;

namespace Website.Server.Services;

public class DocsService : BaseDatabaseService<Doc>
{
    public DocsService(IOptions<RadiumDatabaseSettings> dbSettings, IMapper _mapper) : base("Docs", dbSettings, _mapper)
    {
        
    }
    
    
}