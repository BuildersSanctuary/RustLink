using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Website.Server.Helpers;
using Website.Shared.Models;
using Website.Shared.Models.Database;

namespace Website.Server.Features.Core;

[AutoDTO(typeof(OrderedContainerDTO))]
public class OrderedContainer : IDatabaseObject
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonIgnoreIfDefault]
    public string? Id { get; set; }
    
    public string Name { get; set; }
    
    public string Type { get; set; }
    
    public List<string> Items { get; set; }
}