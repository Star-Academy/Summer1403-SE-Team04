namespace FullTextSearch;

public abstract class FileReader
{
      public List<string> ReadSingleFile(string path,char[] spilliterChars)
      {
            return File.ReadAllText(path)
                  .Split(spilliterChars,
                        StringSplitOptions.RemoveEmptyEntries).ToList();
      }
}