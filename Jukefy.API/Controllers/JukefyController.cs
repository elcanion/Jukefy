using Jukefy.API.Configuration;
using Jukefy.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Jukefy.API.Controllers
{
    [ApiController]
    public class JukefyController : Controller
    {
        private readonly IJukefyServices _jukefyServices;
        public JukefyController(IJukefyServices jukefyServices) 
        {
            _jukefyServices = jukefyServices;
        }
        [AllowAnonymous]
        [HttpGet]
        [Route("getAccessToken")]
        public IActionResult GetAccessToken()
        {
            var result = _jukefyServices.getAccessToken();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("getPlaylists/{userId}")]
        public IActionResult GetPlaylists(string userId) 
        {     
            var result = _jukefyServices.getPlaylists(userId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
            
        }

        [HttpGet]
        [Route("getPlaylistTracks/{playlistId}")]
        public IActionResult GetPlaylistTracks(string playlistId)
        {
            var result = _jukefyServices.getPlaylistTracks(playlistId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("getPlaylistFinalPrice/{playlistId}")]
        public IActionResult GetPlaylistFinalPrice(string playlistId)
        {
            var result = _jukefyServices.getPlaylistFinalPrice(playlistId);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
