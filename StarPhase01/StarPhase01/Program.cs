// See https://aka.ms/new-console-template for more information
using StarPhase01;

class Program
{
    static void Main()
    {
        string nameDataFilePath = @"..\..\..\database\data.json";
        string scoreDstaFilePath = @"..\..\..\database\score.json";
        var studentsList = Input.ReadStudentListFromJsonFile<Student>(nameDataFilePath);
        var coursesList = Input.ReadStudentListFromJsonFile<Course>(scoreDstaFilePath);
        foreach (var courseItem in coursesList)
        {
            Student selectedStudent = studentsList.Find(s => s.StudentNumber == courseItem.StudentNumber);
            selectedStudent.AddCourse(courseItem);
        }
         string output =String.Join("\n", TopStudents.GetTopStudents(studentsList, 3).Select(s => s.ToString()));
         Console.WriteLine(output);
    }
}
