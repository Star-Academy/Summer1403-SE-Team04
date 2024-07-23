using System.Xml.Linq;

namespace StarPhase01;

public class configLoader
{
    public XElement Config { get;}

    public configLoader(string configPath)
    {
         Config = XElement.Load(configPath);
    }

    public  string ReadFromConfig( string key)
    {
        return Config.Element("filePaths")?.Element(key)?.Value;
    }
}