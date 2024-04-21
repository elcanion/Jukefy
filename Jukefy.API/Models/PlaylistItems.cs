using System.Text.Json.Serialization;

namespace Jukefy.API.Models
{
    public class PlaylistItems
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("snapshot_id")]
        public string SnapshotId { get; set; }
    }
}
