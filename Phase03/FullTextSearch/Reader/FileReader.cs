namespace FullTextSearch;

public class FileReader
{
      public List<string> ReadSingleFile(string path)
      {
            var a = Enumerable.Range(0, '0').Union(Enumerable.Range(':', 'A'-':').Union(Enumerable.Range('[', 'a'-'[')));
            return File.ReadAllText(path)
                  .Split(a.Select(i=> (char)i).ToArray(),
                        StringSplitOptions.RemoveEmptyEntries).ToList();
      }
}