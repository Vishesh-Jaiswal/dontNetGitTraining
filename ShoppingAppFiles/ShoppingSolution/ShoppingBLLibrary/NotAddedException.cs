using System.Runtime.Serialization;

namespace ShoppingBLLibrary
{
    [Serializable]
    public class NotAddedException : Exception
    {
        string message;
        public NotAddedException()
        {
            message = "Could not be added.";
        }
        public override string Message => message;

    }
}