namespace GradeCalculatorApp1;

class Program
{
    static void Main(string[] args)
    {
        // Example grade arrays for students
        int[] sophiaGrades = { 93, 87, 98, 95, 100 };
        int[] andrewGrades = { 80, 83, 82, 88, 85 };
        int[] emmaGrades = { 84, 96, 73, 85, 79 };
        int[] loganGrades = { 90, 92, 98, 100, 97 };

        // Calculate the average grades for each student
        decimal sophiaGradeAverage = (decimal)sophiaGrades.Average();
        decimal andrewGradeAverage = (decimal)andrewGrades.Average();
        decimal emmaGradeAverage = (decimal)emmaGrades.Average();
        decimal loganGradeAverage = (decimal)loganGrades.Average();

        // Store the names of the students
        string[] studentNames = { "Sophia", "Andrew", "Emma", "Logan" };
        // Store the average grades in an array
        decimal[] gradeAverages = { sophiaGradeAverage, andrewGradeAverage, emmaGradeAverage, loganGradeAverage };

        // Print the Student and Grade column headers
        Console.WriteLine("Student\tGrade");

        //Call PrintStudentGrades method to provide data
        for (int i = 0; i < studentNames.Length; i++)
        {
            PrintStudentGrades(studentNames[i], gradeAverages[i]);
        }

    }


    //Method to determine letter grade based on average and assign it to a person
    public static char GetLetterGrade(decimal gradeAverage)
    {
        switch (gradeAverage)
        {
            case >= 90:
                return 'A';
            case >= 80:
                return 'B';
            case >= 70:
                return 'C';
            case >= 60:
                return 'D';
            default:
                return 'F';
        }
    }


//create a new method that outputs the letter grade for each student and also prints their name with the letter grade
public static void PrintStudentGrades(string studentName, decimal gradeAverage)
    {
        char letterGrade = GetLetterGrade(gradeAverage);
        Console.WriteLine($"\n{studentName}\t{gradeAverage} {letterGrade}");
    }
}