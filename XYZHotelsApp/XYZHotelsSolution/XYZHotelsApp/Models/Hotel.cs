using System.Text.Json.Serialization;

namespace XYZHotelsApp.Models
{
    public class Hotel
    {
        public int HotelId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public decimal PricePerNight { get; set; }
        [JsonIgnore]
        public List<Room>? Rooms { get; set; }
    }


}
