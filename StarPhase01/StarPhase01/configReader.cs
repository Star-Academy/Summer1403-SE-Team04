using System.Xml.Linq;

namespace StarPhase01;

public static class configReader
{
   public static string ReadFilePathsFromConfig(string configFilePath, string key)
    {
        XElement config = XElement.Load(configFilePath);
        return config.Element("filePaths")?.Element(key)?.Value;
    }
}