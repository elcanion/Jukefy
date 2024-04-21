using System.Text.Json.Serialization;

namespace Jukefy.API.Models
{
    public class Playlist
    {
        [JsonPropertyName("items")]
        public ICollection<Track> Tracks { get; set; }
        [JsonPropertyName("total")]
        public int NumberOfTracks { get; set; }
        public Decimal TrackPrice { get; set; } = 0.49M;
        public Decimal FinalPrice { get; set; }

        public void SetFinalPrice()
        {
            FinalPrice = NumberOfTracks * TrackPrice;
        }
    }
}
