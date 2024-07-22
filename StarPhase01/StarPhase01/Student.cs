using System.Globalization;

namespace StarPhase01;

public class Student
{
    public int StudentNumber { get; set; } 
    public string FirstName{ get; set; }
    public string LastName{ get; set; }
    public List<Course> Courses { get; set; } = new List<Course>();
    public double ScoresSum { get; set; } = 0;
    
    public Student(int studentNumber, string firstName, string lastName)
    {
        StudentNumber = studentNumber;
        FirstName = firstName;
        LastName = lastName;
    }
    

    public override string ToString()
    {
        return String.Format(CultureInfo.CurrentCulture,$"{FirstName} {LastName} {GetAverage():F3} ");
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

