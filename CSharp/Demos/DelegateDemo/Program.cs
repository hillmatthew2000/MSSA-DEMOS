using System;

namespace DelegateDemo
{
    // Custom delegate declaration
    public delegate int Calculator(int a, int b);

    class Program
    {
        // Methods matching the delegate signature
        static int Add(int x, int y) => x + y;
        static int Multiply(int x, int y) => x * y;
        static int Subtract(int x, int y) => x - y;

        // Methods for Action demo
        static void Greet(string name) => Console.WriteLine($"Hello, {name}!");
        static void Farewell(string name) => Console.WriteLine($"Goodbye, {name}!");

        static void Main()
        {
            // --- Custom Delegate Demo ---
            Console.Write("Enter operation (add, multiply, or subtract): ");
            string input = Console.ReadLine();
            Calculator calc = input.ToLower() switch
            {
                "add" => Add,
                "multiply" => Multiply,
                "subtract" => Subtract,
                _ => throw new InvalidOperationException("Invalid Operation")
            };
            int result = calc(3, 4); // Using custom delegate
            Console.WriteLine($"Custom Delegate Result: {result}");

            // --- Func Delegate Demo ---
            Console.Write("Enter operation for Func (add, multiply, subtract): ");
            string funcInput = Console.ReadLine();
            Func<int, int, int> funcCalc = funcInput.ToLower() switch
            {
                "add" => Add,
                "multiply" => Multiply,
                "subtract" => Subtract,
                _ => throw new InvalidOperationException("Invalid operation.")
            };
            int funcResult = funcCalc(5, 6); // Using Func delegate
            Console.WriteLine($"Func Delegate Result: {funcResult}");

            // --- Action Delegate Demo ---
            Console.Write("Enter action (greet or farewell): ");
            string actionInput = Console.ReadLine();
            Action<string> action = actionInput.ToLower() switch
            {
                "greet" => Greet,
                "farewell" => Farewell,
                _ => throw new InvalidOperationException("Invalid action")
            };
            action("Alice"); // Using Action delegate
            action("Bob");
        }
    }
}
