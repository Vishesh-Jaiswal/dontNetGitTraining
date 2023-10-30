using System.Runtime.Serialization;

namespace ClinicBLLibrary
{
    [Serializable]
    public class NoSuchDoctorException : Exception
    {
        string message;
        public NoSuchDoctorException()
        {
            message = "The doctor with the entered id is not present";
        }
        public override string Message => message;


    }
}