namespace FactorialDemo;

class Program
{
    static void Main()
    {
        Console.WriteLine(Factorial(5));
        Console.WriteLine(FactorialIterative(5));
    }

    //Factorial demonstrated using recursion
    static int Factorial(int x)
    {
        if (x == 0)
            return 1;
        else
            return x * Factorial(x - 1);
    }

    //Factorial demonstrated using iteration
    static int FactorialIterative(int x)
    {
        int result = 1;
        for (int i = 1; i <= x; i++)
        {
            result *= i;
        }
        return result;
    }
}