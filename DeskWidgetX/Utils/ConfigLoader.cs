using System.IO;
using System.Text.Json;

namespace DeskWidgetX.Utils;

public class Config
{
    public SpotifyConfig Spotify { get; set; } = new();
    public RiotConfig Riot { get; set; } = new();
    public WidgetSettings Widgets { get; set; } = new();
}

public class SpotifyConfig
{
    public string ClientId { get; set; } = string.Empty;
    public string ClientSecret { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty;
}

public class RiotConfig
{
    public string ApiKey { get; set; } = string.Empty;
    public string SummonerName { get; set; } = string.Empty;
    public string Region { get; set; } = "na1";
}

public class WidgetSettings
{
    public bool ClickThrough { get; set; }
}

public static class ConfigLoader
{
    private const string ConfigFile = "config.json";

    public static Config Load()
    {
        if (!File.Exists(ConfigFile))
        {
            return new Config();
        }

        string json = File.ReadAllText(ConfigFile);
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };
        return JsonSerializer.Deserialize<Config>(json, options) ?? new Config();
    }
}
