namespace SearchAPI.Controllers.Abstraction;

public interface IOutputHandler
{
    void SendOutput(List<string> output);
}