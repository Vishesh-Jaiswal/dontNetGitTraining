using BlogSpotApp.Interfaces;
using BlogSpotApp.Models.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogSpotApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloggerController : ControllerBase
    {
        private readonly IUserService _userService;

        public BloggerController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("register")]
        public ActionResult Register(UserDTO viewModel)
        {

            string message = "";
            try
            {
                var user = _userService.Register(viewModel);
                if (user != null)
                {
                    return Ok(user);
                }
            }
            catch (DbUpdateException exp)
            {
                message = "This Email already exists";
            }
            catch (Exception)
            {

            }
            return BadRequest(message);
        }

        [HttpPost("login")]
        public ActionResult Login(UserDTO userDTO)
        {
            var user = _userService.Login(userDTO);
            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return Unauthorized("Username and Password Mismatch");
            }
        }
    }
}
