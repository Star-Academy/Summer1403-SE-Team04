namespace StarPhase01;

public class Course
{
    private int _studentNumber;
    private string _lesson;
    private double _score;

    public Course(int studentNumber, string lesson, double score)
    {
        _studentNumber = studentNumber;
        _lesson = lesson;
        _score = score;
    }

    public int StudentNumber
    {
        get => _studentNumber;
        set => _studentNumber = value;
    }

    public string Lesson
    {
        get => _lesson;
        set => _lesson = value ?? throw new ArgumentNullException(nameof(value));
    }

    public double Score
    {
        get => _score;
        set => _score = value;
    }
}