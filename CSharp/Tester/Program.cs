using System.Buffers;
using System.Net;
using System.Threading.Channels;

namespace Tester;

class Program
{
    static void Main(string[] args)
    {
        int studentGradeLevel = 2;
        string studentName = "John";

        string gradeDescription = "";
        switch (studentGradeLevel)
        {
            case 1:
                {
                    gradeDescription = "Freshman";
                    break;
                }
            case 2:
                {
                    gradeDescription = "Sophomore";
                    break;
                }
            case 3:
                {
                    gradeDescription = "Junior";
                    break;
                }
            case 4:
                {
                    gradeDescription = "Senior";
                    break;
                }
            default:
                {
                    gradeDescription = "Unspecified Grade Level";
                    break;
                }
        Console.WriteLine($"Student Name: {studentName}, Grade Level: {gradeDescription}");
        }
    }
}