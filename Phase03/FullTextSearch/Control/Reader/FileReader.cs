using FullTextSearch.Reader;

namespace FullTextSearch.Control.Reader;

public class FileReader : IFileReader
{
      private readonly char[] _splitterCharacters;
      private static FileReader? _fileReaderInstance;

      private FileReader()
      {
            _splitterCharacters = GetSplitterChars();
      }
      public static FileReader FileReaderInstance => _fileReaderInstance ??= new FileReader();

      private char[] GetSplitterChars()
      {
            var characters = Enumerable.Range(0, '0')
                  .Union(Enumerable.Range(':', 'A' - ':').Union(Enumerable.Range('[', 'a' - '[')))
                  .Select(i => (char)i);
            return characters as char[] ?? characters.ToArray();
      }

      public List<string> Read(string path)
      {
            return File.ReadAllText(path)
                  .Split(_splitterCharacters,
                        StringSplitOptions.RemoveEmptyEntries).ToList();
      }
}