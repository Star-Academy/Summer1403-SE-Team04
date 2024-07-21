// See https://aka.ms/new-console-template for more information

using System.Xml.Linq;
using StarPhase01;

class Program
{
    static void Main()
    {
        string configFilePath = @"..\..\..\database\config.xml";
        string nameDataFilePath = configReader.ReadFilePathsFromConfig(configFilePath,"nameDataFilePath");
        string scoreDataFilePath = configReader.ReadFilePathsFromConfig(configFilePath,"scoreDataFilePath");
        var studentsList = Input.ReadStudentListFromJsonFile<Student>(nameDataFilePath);
        var coursesList = Input.ReadStudentListFromJsonFile<Course>(scoreDataFilePath);
        foreach (var courseItem in coursesList)
        {
            Student selectedStudent = studentsList.Find(s => s.StudentNumber == courseItem.StudentNumber);
            selectedStudent.AddCourse(courseItem);
        }
         string output =String.Join("\n", TopStudents.GetTopStudents(studentsList, 3).Select(s => s.ToString()));
         Console.WriteLine(output);
    }
}