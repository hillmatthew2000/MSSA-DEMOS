namespace GradeCalculatorAppV2;
 
class Program
{
    static void Main()
    {
        int examAssignments = 5;
        string studentLetterGrade = "";
 
        string[] studentNames = { "Sophia", "Andrew", "Emma", "Logan" };
 
        int[] sophiaScores = { 90, 86, 87, 98, 100, 91, 95 };
        int[] andrewScores = { 92, 89, 81, 96, 90, 95, 91 };
        int[] emmaScores = { 90, 85, 87, 98, 68, 91 };
        int[] loganScores = { 90, 95, 87, 88, 96, 89, 93 };
 
        int[] studentScores = new int[10];
 
        Console.WriteLine("Student\t\tExam Score\tOverall Grade\tExtra Credit\n");
 
        foreach (string studentName in studentNames)
        {
            if (studentName == "Sophia")
                studentScores = sophiaScores;
            else if (studentName == "Andrew")
                studentScores = andrewScores;
            else if (studentName == "Emma")
                studentScores = emmaScores;
            else if (studentName == "Logan")
                studentScores = loganScores;
 
            int sumAssignmentScores = 0;
            int sumExtraCreditAssignmentScores = 0;
 
            int gradedAssignments = 0;
            int gradedExtraCreditAssignments = 0;
 
            decimal studentAvgExamScore = 0;
            decimal studentAvgExtraCreditScore = 0;
 
            decimal studentAvgCombinedScore = 0;
 
            foreach (int score in studentScores)
            {
                gradedAssignments += 1;
 
                if (gradedAssignments <= examAssignments)
                    sumAssignmentScores += score;
                else
                {
                    gradedExtraCreditAssignments += 1;
                    sumExtraCreditAssignmentScores += score;
                }
            }
 
            studentAvgExamScore = (decimal)(sumAssignmentScores) / examAssignments;
            studentAvgExtraCreditScore = (decimal)(sumExtraCreditAssignmentScores) / gradedExtraCreditAssignments;
 
            studentAvgCombinedScore = (decimal)((decimal)sumAssignmentScores + ((decimal)sumExtraCreditAssignmentScores / 10)) / examAssignments;
 
 
            if (studentAvgCombinedScore >= 97)
                studentLetterGrade = "A+";
            else if (studentAvgCombinedScore >= 93)
                studentLetterGrade = "A";
            else if (studentAvgCombinedScore >= 90)
                studentLetterGrade = "A-";
            else if (studentAvgCombinedScore >= 87)
                studentLetterGrade = "B+";
            else if (studentAvgCombinedScore >= 83)
                studentLetterGrade = "B";
            else if (studentAvgCombinedScore >= 80)
                studentLetterGrade = "B-";
            else if (studentAvgCombinedScore >= 77)
                studentLetterGrade = "C+";
            else if (studentAvgCombinedScore >= 73)
                studentLetterGrade = "C";
            else if (studentAvgCombinedScore >= 70)
                studentLetterGrade = "C-";
            else if (studentAvgCombinedScore >= 67)
                studentLetterGrade = "D+";
            else if (studentAvgCombinedScore >= 63)
                studentLetterGrade = "D";
            else if (studentAvgCombinedScore >= 60)
                studentLetterGrade = "D-";
            else
                studentLetterGrade = "F";
 
            decimal extraCreditEffect = studentAvgCombinedScore - studentAvgExamScore;
 
            //Console.WriteLine("Student\t\tExam Score\tOverall Grade\tExtra Credit\n");
            Console.WriteLine($"{studentName}:\t\t{studentAvgExamScore}\t\t{studentAvgCombinedScore}\t{studentLetterGrade}\t{studentAvgExtraCreditScore}\t{extraCreditEffect} pts");
        }
        Console.WriteLine("Press the Enter key to continue");
        Console.ReadLine();
 
    }
}