using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Website.Server.Helpers;
using Website.Shared.Models;
using Website.Shared.Models.Database;

namespace Website.Server.Features.Plugins;

[AutoDTO(typeof(PluginDTO))]
public class Plugin : IDatabaseObject
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string Name { get; set; }
    
    
    
    public string OwnerSteamId { get; set; }
    
    public List<string> Tags { get; set; }
    
    public string Description { get; set; }
    
    public string Github { get; set; }
    
    
    
    
    
    
    

}