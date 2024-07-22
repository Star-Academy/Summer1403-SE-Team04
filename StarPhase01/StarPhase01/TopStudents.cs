namespace StarPhase01;

public static class TopStudents
{ 
    public static Student[] GetTopStudents(List<Student> inputStudentsList, int topStudentsCount)
    {
        return inputStudentsList.OrderByDescending(s => s.GetAverage()).Take(topStudentsCount).ToArray();
    }
}