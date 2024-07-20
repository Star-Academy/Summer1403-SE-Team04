// See https://aka.ms/new-console-template for more information


using System;
using System.Text.Json;
using StarPhase01;

class Program
{
    static void Main()
    {
        string filePath = "data.json";
        string jsonContent = File.ReadAllText(filePath);
        var studentsList = JsonSerializer.Deserialize<List<Student>>(jsonContent);

        filePath = "score.json";
        jsonContent = File.ReadAllText(filePath);
        var coursesList = JsonSerializer.Deserialize<List<Course>>(jsonContent);
        foreach (var courseItem in coursesList)
        {
            Student selectedStudent = studentsList.Find(s => s.StudentNumber == courseItem.StudentNumber);
            selectedStudent.addCourse(courseItem);
        }

        foreach (var student in getTopStudents(studentsList,3))
        {
            Console.WriteLine(student.ToString());
        }
    }

    private static Student[] getTopStudents(List<Student> list, int a)
    {
        if (a > list.Count) a = list.Count;
        Student[] result = new Student[a];
        for (int i = 0; i < a; i++)
        {
            result[i] = new Student(0, "", "");
        }
        foreach (var student in list)
        {
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i].getAverage()<student.getAverage())
                {
                    for (int j = result.Length-1; j > i; j--)
                    {
                        result[j] = result[j - 1];
                    }

                    result[i] = student;
                    break;
                }
            }
        }

        return result;
    }
}
