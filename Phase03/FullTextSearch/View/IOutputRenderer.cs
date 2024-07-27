namespace FullTextSearch.View;

public interface IOutputRenderer
{
    public void Render(List<string> output);
    public void Render(string output);

}