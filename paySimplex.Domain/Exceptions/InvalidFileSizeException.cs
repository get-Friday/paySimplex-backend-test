namespace paySimplex.Domain.Exceptions
{
    public class InvalidFileSizeException : Exception
    {
        public InvalidFileSizeException(string message) : base(message)
        {
        }
    }
}
