namespace SearchAPI.Controllers.Reader;

public class FileProcessingException : Exception
{
    public FileProcessingException(string message) : base(message)
    {
    }
}