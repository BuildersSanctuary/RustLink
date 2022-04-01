using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Website.Server.Helpers;
using Website.Shared.Models;
using Website.Shared.Models.Database;

namespace Website.Server.Models;

[AutoDTO(typeof(DocCategoryDTO))]
public class DocCategory : IDatabaseObject
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    [BsonIgnoreIfDefault]
    public string? Id { get; set; }
    public string Name { get; set; }

    public string? Description { get; set; }
    
    public List<string>? Docs { get; set; }
}




