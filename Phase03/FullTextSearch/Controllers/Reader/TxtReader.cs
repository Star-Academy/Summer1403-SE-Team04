using System.Text.RegularExpressions;
using FullTextSearch.Controllers.Reader.Abstraction;

namespace FullTextSearch.Controllers.Reader;

public class TxtReader : ITxtReader 
{
      private readonly string _splitPattern = @"[^a-zA-Z1-9]";
      private static TxtReader? _fileReaderInstance;
      public static TxtReader TxtReaderInstance => _fileReaderInstance ??= new TxtReader();

      private TxtReader()
      {
      }

      public IEnumerable<string> Read(string path)
      {
            var fileText = File.ReadAllText(path);
            return Regex.Split(fileText, _splitPattern);
      }
}