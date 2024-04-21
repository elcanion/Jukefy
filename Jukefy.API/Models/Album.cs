using System.Text.Json.Serialization;

namespace Jukefy.API.Models
{
    public class Album
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}
