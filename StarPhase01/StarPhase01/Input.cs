using System.Text.Json;

namespace StarPhase01;

public static class Input
{
    public static List<T> ReadStudentListFromJsonFile<T>(string jsonFilePath)
    {
        string jsonContent = File.ReadAllText(jsonFilePath);
        return  JsonSerializer.Deserialize<List<T>>(jsonContent);
    }
    
}