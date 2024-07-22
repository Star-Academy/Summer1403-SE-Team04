namespace FullTextSearch;

public interface IFileReader
{
      public static List<string> ReadSingleFile(string path,char[] spilliterChars)
      {
            return File.ReadAllText(path)
                  .Split(spilliterChars,
                        StringSplitOptions.RemoveEmptyEntries).ToList();
      }
}