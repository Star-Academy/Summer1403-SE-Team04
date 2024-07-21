namespace StarPhase01;

public class Course
{
    public int StudentNumber { get; set; }
    public string Lesson{ get; set; }
    public double Score{ get; set; }
    public Course(int studentNumber, string lesson, double score)
    {
        StudentNumber = studentNumber;
        Lesson = lesson;
        Score = score;
    }

}