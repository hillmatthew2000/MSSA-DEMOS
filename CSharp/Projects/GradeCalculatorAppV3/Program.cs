using System;

namespace Tester;

class Program
{
    static void Main()
    {
        // Student names array
        string[] studentNames = { "Sophia", "Andrew", "Emma", "Logan" };

        // Jagged array to store each student's assignment scores (including extra credit)
        int[][] studentScores = new int[][]
        {
            new int[] { 90, 86, 87, 98, 100, 94, 90 }, // Sophia (5 exams + 2 extra credit)
            new int[] { 92, 89, 81, 96, 90, 89 },      // Andrew (5 exams + 1 extra credit)
            new int[] { 90, 85, 87, 98, 68, 89, 89, 89 }, // Emma (5 exams + 3 extra credit)
            new int[] { 90, 95, 87, 88, 96 }           // Logan (5 exams only)
        };

        // Number of required exam scores
        int examAssignments = 5;

        // Print header
        Console.WriteLine("Student\t\tGrade\n");

        // Outer loop: iterate through each student name
        foreach (string studentName in studentNames)
        {

            int studentIndex = Array.IndexOf(studentNames, studentName);


            int[] currentStudentScores = studentScores[studentIndex];


            int examScoreSum = 0;
            for (int i = 0; i < examAssignments; i++)
            {
                examScoreSum += currentStudentScores[i];
            }

            // Calculate extra credit scores (if any)
            decimal extraCreditSum = 0;
            int extraCreditCount = currentStudentScores.Length - examAssignments;

            if (extraCreditCount > 0)
            {
                // Sum extra credit scores and apply 10% weighting factor
                for (int i = examAssignments; i < currentStudentScores.Length; i++)
                {
                    extraCreditSum += currentStudentScores[i] * 0.1m;
                }
            }

            // Calculate final numeric grade
            decimal finalScore = ((decimal)examScoreSum + extraCreditSum) / examAssignments;

            // Determine letter grade using if-elseif-else construct
            string letterGrade;
            if (finalScore >= 97)
                letterGrade = "A+";
            else if (finalScore >= 93)
                letterGrade = "A";
            else if (finalScore >= 90)
                letterGrade = "A-";
            else if (finalScore >= 87)
                letterGrade = "B+";
            else if (finalScore >= 83)
                letterGrade = "B";
            else if (finalScore >= 80)
                letterGrade = "B-";
            else if (finalScore >= 77)
                letterGrade = "C+";
            else if (finalScore >= 73)
                letterGrade = "C";
            else if (finalScore >= 70)
                letterGrade = "C-";
            else if (finalScore >= 67)
                letterGrade = "D+";
            else if (finalScore >= 63)
                letterGrade = "D";
            else if (finalScore >= 60)
                letterGrade = "D-";
            else
                letterGrade = "F";

            // Format and display the result
            Console.WriteLine($"{studentName}\t\t{finalScore:F1}\t{letterGrade}");
        }
    }
  
}
