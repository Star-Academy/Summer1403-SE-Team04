namespace FullTextSearch.Reader;

public class FileReader
{
      private readonly char[] _splitterCharacters;
      private static FileReader? _fileReaderInstance;

      protected FileReader()
      {
            _splitterCharacters = GetSplitterChars();
      }
      public static FileReader FileReaderInstance => _fileReaderInstance ??= new FileReader();
      
      public List<string> ReadSingleFile(string path)
      {
            return File.ReadAllText(path)
                  .Split(_splitterCharacters,
                        StringSplitOptions.RemoveEmptyEntries).ToList();
      }

      private char[] GetSplitterChars()
      {
            var characters = Enumerable.Range(0, '0')
                  .Union(Enumerable.Range(':', 'A' - ':').Union(Enumerable.Range('[', 'a' - '[')))
                  .Select(i => (char)i);
            return characters as char[] ?? characters.ToArray();
      }
}