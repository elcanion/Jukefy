using Jukefy.API.Models;

namespace Jukefy.API.Services
{
    public interface IJukefyServices
    {
        SpotifyAccessToken getAccessToken();
        List<PlaylistItems> getPlaylists(string userId);
        List<Track> getPlaylistTracks(string playlistId);
        Decimal getPlaylistFinalPrice(string playlistId);
    }
}
