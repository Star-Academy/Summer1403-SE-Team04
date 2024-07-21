using System.Text.Json;

namespace StarPhase01;

public static class JsonLoader
{
    public static List<T> ReadStudentListFromJsonFile<T>(string jsonFilePath)
    {
        var  jsonContent = File.ReadAllText(jsonFilePath);
        return  JsonSerializer.Deserialize<List<T>>(jsonContent);
    }
    
}