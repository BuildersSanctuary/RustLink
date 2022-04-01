using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Website.Server.Services;


public class SteamWebAPI
{
    private string API_KEY;
    private readonly HttpClient httpClient;

    public SteamWebAPI(string key)
    {
        API_KEY = key;
        this.httpClient = new HttpClient();
    }

    public async Task<PlayerSummaryModel> GetSummary(string SteamID)
    {
        var response = await httpClient.GetAsync(
            $"https://api.steampowered.com/ISteamUser/GetPlayerSummaries/v2/?key={API_KEY}&steamids={SteamID}");

        JObject obj = JObject.Parse(await response.Content.ReadAsStringAsync());
        
        var players = obj["response"]?["players"];

        if (players == null || !players.HasValues || players.First == null)
            return null;

        return new PlayerSummaryModel(
            players.First["personaname"]?.ToString(),
            players.First["profileurl"]?.ToString(),
            players.First["avatarfull"]?.ToString());
    }
}

public record PlayerSummaryModel(string Nickname, string ProfileURL, string Avatar);