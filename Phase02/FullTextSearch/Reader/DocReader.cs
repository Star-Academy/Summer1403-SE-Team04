using System.Runtime.Versioning;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FullTextSearch
{
    public class DocReader : FileReader
    {
        public List<Document> ReadDocs()
        {
            try
            {
                return Directory.GetFiles(Resources.documentsPath, "*.*", SearchOption.AllDirectories)
                    .Select(s => new Document(s, ReadSingleFile(s)))
                    .ToList();
            }
            catch (DirectoryNotFoundException d)
            {
                Console.WriteLine(d);
                throw new FileProcessingException(d.Message);
            }
            catch (FileLoadException e)
            {
                Console.WriteLine(e);
                throw new FileProcessingException(e.Message);
            }
            catch (IOException d)
            {
                Console.WriteLine(d);
                throw new FileProcessingException(d.Message);
            }
        }
    }
}