﻿namespace GPACalculatorApp;

class Program
{
    static void Main(string[] args)
    {
        // String variable storing student name
        string student = "Sophia";

        // Array storing the grade points for student
        int[] gradePoints = { 4, 3, 3, 3, 4 };

        // Array storing the credit hours for each course
        int[] creditHours = { 3, 3, 4, 4, 3 };

        // Array storing the names of each class
        string[] classes = { "English 101", "Algebra 101", "Biology 101", "Computer Science I", "Psychology 101" };

        // Print the layout for the table
        Console.WriteLine($"Student: {student}");
        Console.WriteLine($"\n{"Course",-25}{"Grade",8}{"Credit Hours",18}");
        Console.WriteLine(new string('-', 51));

        // Create a loop that iterates through the creditHours and gradePoints arrays and prints them
        for (int i = 0; i < gradePoints.Length; i++)
        {
            Console.WriteLine($"{classes[i],-25}{gradePoints[i],8}{creditHours[i],13}");
        }

        int sumPoints = 0;
        int sumHours = 0;
        for (int i = 0; i < gradePoints.Length; i++)
        {
            sumPoints += gradePoints[i] * creditHours[i];
            sumHours += creditHours[i];
        }
        decimal finalGPA = (decimal)sumPoints / sumHours;

        // Print the final GPA
        Console.WriteLine($"Final GPA: {finalGPA:F2}");
    }

}