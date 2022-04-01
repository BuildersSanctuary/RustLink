using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Website.Server.Models;
using Website.Shared.Constants;

namespace Website.Shared.Models.Database;

public class DocCategoryDTO : IDTO
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public List<string>? Docs { get; set; }
    
    
    public static async Task<List<DocCategoryDTO>?> GetAllFromAPI(HttpClient httpClient)
    {
        var response = await httpClient.GetAsync("api/doccategory");

        if (response.StatusCode != HttpStatusCode.OK)
            return null;
        
        return JsonSerializer.Deserialize<List<DocCategoryDTO>>(await response.Content.ReadAsStringAsync(), JsonOptions.CaseInsensitive);
    }
}



