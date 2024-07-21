using System.Globalization;

namespace StarPhase01;

public class Student
{
    private int _studentNumber;
    private string _firstName;
    private string _lastName;
    private List<Course> _courses;
    private double _scoresSum;
    
    public Student(int studentNumber, string firstName, string lastName)
    {
        _studentNumber = studentNumber;
        _firstName = firstName;
        _lastName = lastName;
        _courses = new List<Course>();
        _scoresSum = 0;
    }

    public int StudentNumber
    {
        get => _studentNumber;
        set => _studentNumber = value;
    }

    public string FirstName
    {
        get => _firstName;
        set => _firstName = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string LastName
    {
        get => _lastName;
        set => _lastName = value ?? throw new ArgumentNullException(nameof(value));
    }

    public List<Course> Courses
    {
        get => _courses;
        set => _courses = value ?? throw new ArgumentNullException(nameof(value));
    }

    public override string ToString()
    {
        return ToString(CultureInfo.CurrentCulture);
    }

    public string ToString(IFormatProvider formatProvider)
    {
        return String.Format(formatProvider,"{0} {1} {2:F3} ",_firstName,_lastName,getAverage());
    }

    public void addCourse(Course newCourse)
    {
        _courses.Add(newCourse);
        _scoresSum += newCourse.Score;
    }
    public double getAverage()
    {
        return _courses.Count == 0 ? 0 : _scoresSum / _courses.Count;
    }
}

