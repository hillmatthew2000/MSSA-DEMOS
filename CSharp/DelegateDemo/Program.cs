using System.ComponentModel;

namespace DelegateDemo;

class Program
{
    static int Add(int x, int y) => x + y;
    static int Multiply(int x, int y) => x * y;
    static int Subtract(int x, int y) => x - y;
    static void Main()
    {
        Calculator calc;
        

        Console.Write("Enter operation (add, multiply, or subtract): ");
        string input = Console.ReadLine();

        calc = input.ToLower() switch
        {
            "add" => Add,
            "multiply" => Multiply,
            "subtract" => Subtract,
            _ => throw new InvalidOperationException("Invalid Operation")
        };

        int result = calc(3, 4);
        Console.WriteLine($"Result: {result}");
    }
}

public delegate int Calculator(int a, int b);
