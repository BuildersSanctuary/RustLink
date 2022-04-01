using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks; 
using Website.Shared.Constants;
using Website.Shared.Models;

namespace Website.Server.Models;

public class DocDTO : IDTO
{
    public string Name { get; set; }
    public string Markdown { get; set; } 

    
    public static async Task<DocDTO?> GetFromAPI(HttpClient httpClient, string PageID)
    {
        var response = await httpClient.GetAsync("api/docs/" + PageID);

        if (response.StatusCode != HttpStatusCode.OK)
            return null;
        
        return JsonSerializer.Deserialize<DocDTO>(await response.Content.ReadAsStringAsync(), JsonOptions.CaseInsensitive);
    }
}