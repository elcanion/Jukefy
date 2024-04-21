using Jukefy.API.Configuration;
using Jukefy.API.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Jukefy.API.Services
{
    public class JukefyServices : IJukefyServices
    {
        private readonly IConfiguration _spotifyConfiguration;
        private readonly IHttpClientFactory _httpClientFactory;
        private static string accessToken;
        public JukefyServices(
        IConfiguration spotifyConfiguration,
        IHttpClientFactory httpClientFactory)
        {
            _spotifyConfiguration = spotifyConfiguration;
            _httpClientFactory = httpClientFactory;
        }

        public SpotifyAccessToken getAccessToken()
        {

            SpotifyConfigurationOptions spotifyConfigurationOptions = new();
            _spotifyConfiguration.GetSection("Spotify").Bind(spotifyConfigurationOptions);
            using HttpClient httpClient = _httpClientFactory.CreateClient();

            var form = new Dictionary<string, string>();
            form.Add("grant_type", spotifyConfigurationOptions.GrantType);
            form.Add("client_id", spotifyConfigurationOptions.ClientId);
            form.Add("client_secret", spotifyConfigurationOptions.ClientSecret);
            var request = new HttpRequestMessage(HttpMethod.Post, "https://accounts.spotify.com/api/token")
            {
                Content = new FormUrlEncodedContent(form)
            };
            var response = httpClient.SendAsync(request).Result;
            SpotifyAccessToken getAccessTokenResponse = JsonSerializer.Deserialize<SpotifyAccessToken>(response.Content.ReadAsStringAsync().Result);
            accessToken = getAccessTokenResponse.AccessToken;
            return getAccessTokenResponse;
        }

        public List<PlaylistItems> getPlaylists(string userId)
        {
            // 31k654u7mevkgkvwqqcgs32o3r5e
            using HttpClient httpClient = _httpClientFactory.CreateClient();
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", accessToken);

            var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.spotify.com/v1/users/{userId}/playlists");
            
            var response = httpClient.SendAsync(request).Result;
            Playlists playlists = new();
            playlists = JsonSerializer.Deserialize<Playlists>(response.Content.ReadAsStringAsync().Result);
            return playlists.playlistItems.ToList();
        }

        public List<Track> getPlaylistTracks(string playlistId)
        {
            // 31k654u7mevkgkvwqqcgs32o3r5e
            using HttpClient httpClient = _httpClientFactory.CreateClient();
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", accessToken);

            var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.spotify.com/v1/playlists/{playlistId}/tracks");

            var response = httpClient.SendAsync(request).Result;
            Playlist playlist = new();
            playlist = JsonSerializer.Deserialize<Playlist>(response.Content.ReadAsStringAsync().Result);
            playlist.SetFinalPrice();
            return playlist.Tracks.ToList();
        }

        public Decimal getPlaylistFinalPrice(string playlistId)
        {
            // 31k654u7mevkgkvwqqcgs32o3r5e
            using HttpClient httpClient = _httpClientFactory.CreateClient();
            httpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", accessToken);

            var request = new HttpRequestMessage(HttpMethod.Get, $"https://api.spotify.com/v1/playlists/{playlistId}/tracks");

            var response = httpClient.SendAsync(request).Result;
            Playlist playlist = new();
            playlist = JsonSerializer.Deserialize<Playlist>(response.Content.ReadAsStringAsync().Result);
            playlist.SetFinalPrice();
            return playlist.FinalPrice;
        }
    }
}
