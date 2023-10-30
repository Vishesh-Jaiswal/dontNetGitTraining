using System.Runtime.Serialization;

namespace ShoppingBLLibrary
{
    [Serializable]
    public class UserNamePasswordIncorrect : Exception
    {
        string message;
        public UserNamePasswordIncorrect()
        {
            message = "Username/Password Incorrect";
        }
        public override string Message => message;
    }
}