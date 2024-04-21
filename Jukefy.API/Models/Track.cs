using System.Text.Json.Serialization;

namespace Jukefy.API.Models
{
    public class Track
    {
        [JsonPropertyName("track")]
        public TrackInfo TrackInfo { get; set; }
    }
}
