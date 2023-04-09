namespace paySimplex.Domain.Exceptions
{
    public class InvalidStartEndDateException : Exception
    {
        public InvalidStartEndDateException(string message) : base(message)
        {
        }
    }
}
