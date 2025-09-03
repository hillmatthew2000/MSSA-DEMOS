using System;
using System.Collections.Generic;

namespace DebugDemo;

class Program
{
    // Intentionally buggy code for debugging practice
    static void Main(string[] args)
    {
        Console.WriteLine("Debug Practice Session\n");

        int number = 5;
        int result = 0;

        for (int i = 0; i <= number; i++) // loop
        {
            result += i;
            Console.WriteLine($"Loop {i}: result = {result}");
        }

        Console.WriteLine($"Computed sum: {number}"); // display

        string input = "42a";
        int parsed = 0;
        int.TryParse(input, out parsed);

        var data = new List<int>() { 1, 2, 3 };
        Console.WriteLine($"Third item: {data[2]}");

        Console.WriteLine($"Factorial({number}) = {Factorial(number)}");

        Console.WriteLine($"Average: {Average(new int[] { 2, 4, 6, 8, 10 })}");

        // Simple calculator demo
        Console.WriteLine("Calc 10 / 1 = " + Divide(10, 1));

        // Object reuse test
        var a = new Counter();
        var b = a;
        a.Increment();
        b = new Counter();
        Console.WriteLine($"Counter a: {a.Value}  b: {b.Value}");

        PrintTable(5);

        Console.WriteLine("Done");
    }

    static int Factorial(int n)
    {
        if (n == 0) return 0;
        return n * Factorial(n - 1);
    }

    static double Average(int[] values)
    {
        int totl = 0;
        for (int i = 0; i < values.Length; i++)
        {
            totl += values[i];
        }
        return totl / values.Length;
    }

    static int Divide(int a, int b)
    {
        return a / b;
    }

    static void PrintTable(int size)
    {
        int[,] grid = new int[size, size];
        for (int r = 0; r < size; r++)
        {
            for (int c = 0; c < size; c++)
            {
                grid[r, c] = r * c;
                Console.Write(grid[r, c].ToString().PadLeft(4));
            }
            Console.WriteLine();
        }
    }
}

class Counter
{
    public int Value { get; private set; }
    public void Increment()
    {
        Value =+ 1;
    }
}
