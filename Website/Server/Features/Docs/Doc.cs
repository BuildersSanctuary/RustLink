using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Website.Server.Helpers;
using Website.Shared.Models;

namespace Website.Server.Models;

[AutoDTO(typeof(DocDTO))]
public class Doc : IDatabaseObject
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonIgnoreIfDefault]
    public string? Id { get; set; }
    
    public string Name { get; set; }
    
    public string Markdown { get; set; }
}