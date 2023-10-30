using System.Runtime.Serialization;

namespace ShoppingBLLibrary
{
    [Serializable]
    public class UnableToAddCustomer : Exception
    {
        string message;
        public UnableToAddCustomer()
        {
            message = "The Cutomer cannot be added";
        }
        public override string Message => message;
    }
}