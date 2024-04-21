using System.Text.Json.Serialization;

namespace Jukefy.API.Models
{
    public class Artist
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
