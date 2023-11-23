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

//------------------------------------------REGISTER USER----------------------------------
        /// <summary>
        /// API for User Resgistration
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost("Register")]
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

//------------------------------------------Login USER----------------------------------
        /// <summary>
        /// API for User Login
        /// </summary>
        /// <param name="userDTO">UserDTO</param>
        /// <returns></returns>
        [HttpPost("Login")]
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
