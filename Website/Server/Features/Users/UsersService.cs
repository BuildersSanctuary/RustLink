using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Website.Server.Extensions;
using Website.Server.Models;
using Website.Shared.Models;

namespace Website.Server.Services;


public class UsersService : BaseDatabaseService<RadiumUser>
{
    public UsersService(IOptions<RadiumDatabaseSettings> dbSettings, IMapper _mapper) : base("Users", dbSettings, _mapper)
    {
        
    }
    
    
    public async Task<T?> GetFromSteamIDAsync<T>(string? steamID)
    {
        if (steamID == null)
            return default;
        
        var user = await collection.Find(x => x.SteamId == steamID).FirstOrDefaultAsync();
        if (user == null)
            return default;
            
        return user.ToDTO<T>(_mapper);
    }
    
    public async Task LinkDiscordAndSteam(string? steamID, string discordID, string discordName)
    {
        UpdateDefinition<RadiumUser> setDiscord = new UpdateDefinitionBuilder<RadiumUser>()
            .Set(f => f.DiscordId, discordID)
            .Set(f => f.DiscordName, discordName);

        await collection.UpdateOneAsync(user => user.SteamId == steamID, setDiscord);
    }
} 