namespace Equations.Exceptions
{
    public class InvalidQuadraticCoefficientException : ArgumentException
    {
        public InvalidQuadraticCoefficientException()
        {
        }

        public InvalidQuadraticCoefficientException(string message)
            : base(message)
        {
        }

        public InvalidQuadraticCoefficientException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
