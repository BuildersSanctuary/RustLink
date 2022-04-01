using System;
using System.Runtime.Serialization;

namespace Website.Shared.Models.Database;

public class RadiumUserDTO : IDTO
{ 
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
}