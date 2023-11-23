using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XYZHotelsApp.Interfaces;
using System.Net.Mime;
using XYZHotelsApp.Models;
using XYZHotelsApp.Exceptions;

namespace XYZHotelsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {

        private readonly IHotelService _hotelService;

        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _hotelService.GetHotels();
                return Ok(result);
            }
            catch (NoHotelsAvailableException e)
            {
                errorMessage = e.Message;
            }
            return BadRequest(errorMessage);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("Add")]
        public ActionResult Create(Hotel hotel)
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _hotelService.AddHotel(hotel);
                return Ok(result);
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
            }
            return BadRequest(errorMessage);
        }



        [HttpPost("Remove")]
        public ActionResult Remove(Hotel hotel)
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _hotelService.RemoveHotel(hotel);
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
