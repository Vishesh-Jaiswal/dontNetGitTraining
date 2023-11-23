using System.Runtime.Serialization;
namespace XYZHotelsApp.Exceptions
{
    public class RoomIsBooked : Exception
    {
        string message;
        public RoomIsBooked()
        {
            message = "Room is already Booked";
        }
        public override string Message => message;
    }
}
