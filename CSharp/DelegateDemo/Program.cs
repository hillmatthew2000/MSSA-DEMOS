using System.ComponentModel;

namespace DelegateDemo;

class Program
{
        static int Add(int x, int y) => x + y;
        static int Multiply(int x, int y) => x * y;
    static void Main()
    {
        Calculator calc;

        Console.Write("Enter operation (add or multiply): ");
        string input = Console.ReadLine();

        if (input == "add")
            calc = Add;
        else
            calc = Multiply;

        int result = calc(3, 4);
        Console.WriteLine($"Result: {result}");
    }
}

public delegate int Calculator(int a, int b);
