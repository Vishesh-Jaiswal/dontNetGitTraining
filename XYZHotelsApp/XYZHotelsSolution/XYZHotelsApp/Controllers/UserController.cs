using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XYZHotelsApp.Interfaces;
using XYZHotelsApp.Models.DTOs;
using XYZHotelsApp.Services;

namespace XYZHotelsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
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
                message = "Duplicate username";
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
