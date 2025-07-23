using System.Reflection.Metadata;
using System.Runtime.InteropServices;

namespace Tester;

class Program
{
    static void Main(string[] args)
    {
        Random dice = new Random();
        int r1 = dice.Next(1, 7);
        int r2 = dice.Next(1, 7);
        int r3 = dice.Next(1, 7);
        Console.WriteLine($"You rolled: {r1} and {r2} and {r3}");
        int rollSum = r1 + r2 + r3;

        if (r1 == r2 && r2 == r3)
        {
            rollSum += 6;
            Console.WriteLine("You got a bonus of 6 points");
        }
        else if (r1 == r2 || r1 == r3 || r2 == r3)
        {
            rollSum += 2;
            Console.WriteLine("You got a bonus of 2");
        }

        if (rollSum >= 15)
        {
            Console.WriteLine("Enter your initials:");
            string initials = Console.ReadLine();
            Console.WriteLine($"You Got The New High Score: {rollSum} --> {initials}");
        }
        else if (rollSum < 6)
        {
            Console.WriteLine("You Are A Low Score Loser");
        }
        else
        {
            Console.WriteLine($"Your score is: {rollSum}");
        }
        

    }
    
}

