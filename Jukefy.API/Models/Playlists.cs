using System.Text.Json.Serialization;

namespace Jukefy.API.Models
{
    public class Playlists
    {
        [JsonPropertyName("total")]
        public int Total { get; set; }
        [JsonPropertyName("items")]
        public ICollection<PlaylistItems> playlistItems { get; set; }
    }
}
