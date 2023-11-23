using BlogSpotApp.Interfaces;
using BlogSpotApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogSpotApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [Authorize(Roles = "Reader")]
        [HttpPost("AddComment")]
        public ActionResult AddComment(Comment comment)
        {
            string errorMessage;
            try
            {
                var result = _commentService.AddComment(comment);
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
