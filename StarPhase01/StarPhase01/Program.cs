// See https://aka.ms/new-console-template for more information

using System.Text.Json;
using StarPhase01;

class Program
{
    static void Main()
    {
        string filePath = @"..\..\..\database\data.json";
        string jsonContent = File.ReadAllText(filePath);
        var studentsList = JsonSerializer.Deserialize<List<Student>>(jsonContent);

        filePath = @"..\..\..\database\score.json";
        jsonContent = File.ReadAllText(filePath);
        var coursesList = JsonSerializer.Deserialize<List<Course>>(jsonContent);
        foreach (var courseItem in coursesList)
        {
            Student selectedStudent = studentsList.Find(s => s.StudentNumber == courseItem.StudentNumber);
            selectedStudent.AddCourse(courseItem);
        }

        foreach (var student in TopStudents.GetTopStudents(studentsList,3))
        {
            Console.WriteLine(student.ToString());
        }
    }

    
}
