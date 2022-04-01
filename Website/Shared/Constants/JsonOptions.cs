using System.Text.Json;

namespace Website.Shared.Constants;

public static class JsonOptions
{
    public static JsonSerializerOptions CaseInsensitive = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true
    };
}