using System.Text.Json.Serialization;

namespace Jukefy.API.Configuration
{
    public class SpotifyConfigurationOptions
    {
        public string GrantType { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
    }
}
