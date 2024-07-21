using System.Globalization;

namespace StarPhase01;

public class Student
{
    public int StudentNumber { get; set; }
    public string FirstName{ get; set; }
    public string LastName{ get; set; }
    public List<Course> Courses{ get; set; }
    public double ScoresSum{ get; set; }
    
    public Student(int studentNumber, string firstName, string lastName)
    {
        StudentNumber = studentNumber;
        FirstName = firstName;
        LastName = lastName;
        Courses = new List<Course>();
        ScoresSum = 0;
    }
    

    public override string ToString()
    {
        return String.Format(CultureInfo.CurrentCulture,"{0} {1} {2:F3} ",FirstName,LastName,GetAverage());
    }

    public void AddCourse(Course newCourse)
    {
        Courses.Add(newCourse);
        ScoresSum += newCourse.Score;
    }
    public double GetAverage()
    {
        return Courses.Count == 0 ? 0 : ScoresSum / Courses.Count;
    }
}

