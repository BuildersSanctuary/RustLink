using System;
using AutoMapper;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Website.Server.Helpers;
using Website.Shared.Models;
using Website.Shared.Models.Database;

namespace Website.Server.Models;


[AutoDTO(typeof(RadiumUserDTO))]
public class RadiumUser : IDatabaseObject
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string Name { get; set; }
    public string SteamId { get; set; }
    
    public string? DiscordId { get; set; }
    public string? DiscordName { get; set; }
        
    // settings
    public string Role { get; set; }
    public DateTime CreateDate { get; set; }
        
    // bio
    public string? AvatarImageURL { get; set; }
    public string Color { get; set; }
    public string Biography { get; set; }
        
    
    
    
        
    [BsonIgnore]
    public string AvatarUrl => AvatarImageURL ?? "/img/profiles/default_avatar.png";
    [BsonIgnore]
    public string SteamProfileUrl => "https://steamcommunity.com/profiles/" + SteamId;
    [BsonIgnore]
    public string BackgroundColor => Color ?? "#0066ff";
}