// See https://aka.ms/new-console-template for more information

using System.Xml.Linq;
using StarPhase01;

class Program
{
    static void Main()
    {
        try
        { 
            var nameDataFilePath = Resources.DataFilePath;
            var scoreDataFilePath = Resources.ScoreFilePath;
            var studentsList = JsonLoader.ReadStudentListFromJsonFile<Student>(nameDataFilePath);
            var coursesList = JsonLoader.ReadStudentListFromJsonFile<Course>(scoreDataFilePath);
            foreach (var courseItem in coursesList)
            {
                var  selectedStudent = studentsList.Find(s => s.StudentNumber == courseItem.StudentNumber);
                selectedStudent.AddCourse(courseItem);
            }
            var output =String.Join("\n", TopStudents.GetTopStudents(studentsList, 3).Select(s => s.ToString()));
            Console.WriteLine(output);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine("let it go argument Exception");
            throw;
        }
    }
}