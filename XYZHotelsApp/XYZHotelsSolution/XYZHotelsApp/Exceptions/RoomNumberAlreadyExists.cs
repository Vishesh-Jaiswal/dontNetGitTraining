using System.Runtime.Serialization;
namespace XYZHotelsApp.Exceptions
{
    public class RoomNumberAlreadyExists : Exception
    {
        string message;
        public RoomNumberAlreadyExists()
        {
            message = "RoomNumber is already present";
        }
        public override string Message => message;
    }
}