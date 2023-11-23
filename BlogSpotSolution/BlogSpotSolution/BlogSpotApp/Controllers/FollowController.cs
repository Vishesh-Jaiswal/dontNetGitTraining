using BlogSpotApp.Interfaces;
using BlogSpotApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogSpotApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FollowController : ControllerBase
    {
        private readonly IFollowService _followService;

        public FollowController(IFollowService followService)
        {
            _followService = followService;
        }


        [Authorize(Roles = "Reader")]
        [HttpPost("Follow")]
        public ActionResult Follow(Follow follow)
        {
            string errorMessage;
            try
            {
                var result = _followService.AddFollow(follow);
                return Ok(result);
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
            }
            return BadRequest(errorMessage);
        }
    }
}
