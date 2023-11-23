using System.Runtime.Serialization;

namespace XYZHotelsApp.Exceptions
{
    public class RoomCouldNotBeAdded : Exception
    {
        string message;
        public RoomCouldNotBeAdded()
        {
            message = "Room Could not be Added";
        }
        public override string Message => message;
    }
}