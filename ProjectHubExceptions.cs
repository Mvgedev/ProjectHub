namespace ProjectHub.Api.Exceptions
{

    public abstract class CustomException : Exception
    {
        public int StatusCode { get; }

        protected CustomException(string message, int statusCode): base(message)
        {
            StatusCode = statusCode;
        }
    }

    public class UpdateFailedException: CustomException
    {
        public UpdateFailedException(string message) : base(message, StatusCodes.Status500InternalServerError) { }

    }

    public class DeleteFailedException: CustomException
    {
        public DeleteFailedException(string message) : base(message, StatusCodes.Status500InternalServerError) { }
    }
}