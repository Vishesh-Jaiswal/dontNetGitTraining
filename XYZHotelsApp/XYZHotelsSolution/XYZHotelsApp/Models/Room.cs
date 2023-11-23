using System.Text.Json.Serialization;

namespace XYZHotelsApp.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        public int RoomNumber { get; set; }
        public int HotelId { get; set; }
        [JsonIgnore]
        public Hotel? Hotel { get; set; }
        [JsonIgnore]
        public List<Reservation>? Reservations { get; set; }
        public RoomStatus Status { get; set; }

        public DateTime? AvailableAgainAt { get; set; }
    }

    public enum RoomStatus
    {
        Available,
        Reserved
    }


}
