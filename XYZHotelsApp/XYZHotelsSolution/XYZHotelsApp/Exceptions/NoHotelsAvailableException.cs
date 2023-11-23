namespace XYZHotelsApp.Exceptions
{
    public class NoHotelsAvailableException : Exception
    {
        string message;
        public NoHotelsAvailableException()
        {
            message = "There are currently no hotels available";
        }

        public override string Message => message;
    }
}
  