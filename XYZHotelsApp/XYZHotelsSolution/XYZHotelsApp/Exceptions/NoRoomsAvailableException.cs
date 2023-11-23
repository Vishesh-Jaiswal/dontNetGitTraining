using System.Runtime.Serialization;

namespace XYZHotelsApp.Exceptions
{

    public class NoRoomsAvailableException : Exception
    {
        string message;
        public NoRoomsAvailableException()
        {
            message = "There are no rooms available";
        }
        public override string Message => message;
    }
}