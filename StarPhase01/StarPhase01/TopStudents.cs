namespace StarPhase01;

public static class TopStudents
{
    
    public static Student[] GetTopStudents(List<Student> inputStudentsList, int topStudentsCount)
    {
        if (topStudentsCount > inputStudentsList.Count) topStudentsCount = inputStudentsList.Count;
        Student[] result = new Student[topStudentsCount];
        result = Enumerable.Range(0, topStudentsCount)
            .Select(i => new Student(0, string.Empty, string.Empty))
            .ToArray();
        foreach (var student in inputStudentsList)
        {
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i].GetAverage()<student.GetAverage())
                {
                    shiftDown(result, i, student);
                    break;
                }
            }
        }

        return result;
    }

    private static void shiftDown(Student[] result, int shiftIndex, Student newStudent)
    {
        for (int j = result.Length-1; j > shiftIndex; j--)
        {
            result[j] = result[j - 1];
        }

        result[shiftIndex] = newStudent;
    }
}