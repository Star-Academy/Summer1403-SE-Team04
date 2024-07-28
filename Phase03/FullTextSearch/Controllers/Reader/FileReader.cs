using System.Text.RegularExpressions;
using FullTextSearch.Controllers.Reader.Abstraction;

namespace FullTextSearch.Controllers.Reader;

public class FileReader : IFileReader 
{
      private readonly char[] _splitterCharacters;
      private static FileReader? _fileReaderInstance;
      public static FileReader FileReaderInstance => _fileReaderInstance ??= new FileReader();

      private FileReader()
      {
            _splitterCharacters = GetSplitterChars();
      }

      private char[] GetSplitterChars()
      {
            var characters = new Regex(@"[0-9:;A-Z\[\\\]a-z]").ToString().ToCharArray();
            return characters;
      }

      public IEnumerable<string> Read(string path)
      {
            return File.ReadAllText(path)
                  .Split(_splitterCharacters,
                        StringSplitOptions.RemoveEmptyEntries).ToList();
      }
}