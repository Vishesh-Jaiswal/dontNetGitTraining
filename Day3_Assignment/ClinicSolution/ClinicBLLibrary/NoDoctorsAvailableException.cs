using System.Runtime.Serialization;

namespace ClinicBLLibrary
{
    [Serializable]
    public class NoDoctorsAvailableException : Exception
    {
        string message;
        public NoDoctorsAvailableException()
        {
            message = "No doctors are available currently";
        }

        public override string Message => message;
    }
}