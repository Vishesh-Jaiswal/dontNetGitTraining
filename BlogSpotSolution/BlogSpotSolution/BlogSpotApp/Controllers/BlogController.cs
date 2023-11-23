using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using BlogSpotApp.Exceptions;
using BlogSpotApp.Interfaces;
using BlogSpotApp.Models;

namespace BlogSpotApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }
//------------------------------------------CREATE BLOG----------------------------------
        /// <summary>
        /// API to create a blog.
        /// </summary>
        /// <param name="blog"></param>
        /// <returns></returns>
        [Authorize(Roles = "Blogger")]
        [HttpPost("Create")]
        public ActionResult CreateBlog(Blog blog)
        {
            string errorMessage;
            try
            {
                var result = _blogService.AddPost(blog);
                return Ok(result);
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
            }
            return BadRequest(errorMessage);
        }
//------------------------------------------DELETE BLOG----------------------------------
        /// <summary>
        ///  API to delete a blog.
        /// </summary>
        /// <param name="blog"></param>
        /// <returns></returns>
        [Authorize(Roles = "Blogger")]
        [HttpPost("Delete")]
        public ActionResult DeleteBlog(Blog blog)
        {
            var result = _blogService.DeletePost(blog);
            if (result!=null)
            {
                return Ok(result);
            }

            return BadRequest("Blog could not be delete");
        }
//------------------------------------------EDIT BLOG----------------------------------
        [Authorize(Roles = "Blogger")]
        [HttpPost("Edit")]
        public ActionResult EditBlog(Blog blog)
        {
            var result = _blogService.EditPost(blog);
            if (result != null)
            {
                return Ok(result);
            }

            return BadRequest("Blog could not be delete");
        }
//------------------------------------------GET ALL BLOGS----------------------------------
        [HttpGet]
        public ActionResult Get()
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _blogService.GetBlogs();
      
                return Ok(result);
            }
            catch (NoBlogsAvailableException e)
            {
                errorMessage = e.Message;
            }
            return BadRequest(errorMessage);
        }
    }
}
