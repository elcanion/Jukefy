using System.Text.Json.Serialization;

namespace Jukefy.API.Models
{
    public class TrackInfo
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("album")]
        public Album Album { get; set; }
        [JsonPropertyName("artists")]
        public ICollection<Artist> Artists { get; set; }
    }
}
