using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using XYZHotelsApp.Interfaces;
using XYZHotelsApp.Models;
using XYZHotelsApp.Services;

namespace XYZHotelsApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        [HttpPost("Booking")]
        public ActionResult BookRoom(Reservation reservation)
        {
            string errorMessage = string.Empty;
            try
            {
                var result = _reservationService.BookRoom(reservation);
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
