using System.Runtime.Serialization;

namespace ClinicBLLibrary
{
    [Serializable]
    public class NotAddedException : Exception
    {
        string message;
        public NotAddedException()
        {
            message = "Doctor was not addedd.";
        }
        public override string Message => message;

    }
}