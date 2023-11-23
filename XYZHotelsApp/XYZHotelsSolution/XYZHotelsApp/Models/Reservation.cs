using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace XYZHotelsApp.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public int RoomId { get; set; }
        public DateTime? CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }
        [JsonIgnore]
        public Room? Room { get; set; }
        [JsonIgnore]
        public User? Users { get; set; }
        [ForeignKey("Username")]
        public string Username { get; set; }
    }


}
