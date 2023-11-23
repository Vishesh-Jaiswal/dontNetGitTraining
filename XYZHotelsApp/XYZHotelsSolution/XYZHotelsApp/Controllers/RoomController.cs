using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XYZHotelsApp.Exceptions;
using XYZHotelsApp.Interfaces;
using XYZHotelsApp.Models;
using XYZHotelsApp.Services;

namespace XYZHotelsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }
        [HttpGet]
        public ActionResult GetRooms()
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _roomService.GetAllRooms();

                return Ok(result);
            }
            catch (NoRoomsAvailableException e)
            {
                errorMessage = e.Message;
            }
            return BadRequest(errorMessage);
        }

        [HttpPost("AddRoom")]
        public ActionResult Add(Room room)
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _roomService.AddRoom(room);
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
