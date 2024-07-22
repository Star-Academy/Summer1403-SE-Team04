using System.Runtime.Versioning;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FullTextSearch
{
    public class DocReader : IFileReader
    {
        public static List<Document> ReadDocs()
        {
            try
            {
                return Directory.GetFiles(Resources.documentsPath, "*.*", SearchOption.AllDirectories)
                    .Select(s => new Document(s, IFileReader.ReadSingleFile(s, new char[] { ' ', ',', '.', ':', '(', ')', '\n' })))
                    .ToList();
            }
            catch (FileLoadException e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}