namespace FullTextSearch.View;

public interface IOutputRenderer
{
    void Render(List<string> output);
    void Render(string output);
}