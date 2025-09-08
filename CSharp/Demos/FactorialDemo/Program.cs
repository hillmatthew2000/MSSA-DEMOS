namespace FactorialDemo;

class Program
{
    static void Main(string[] args)
    {
        int fact, num;
        Console.WriteLine("Enter a number to find factorial");
        num = Convert.ToInt32(Console.ReadLine());
        fact = factorial(num);
        Console.WriteLine($"Factorial of {num} is {fact}");
    }

    public static int factorial(int num)
    {
        if (num == 0)
            return 1;
        else
            return num * factorial(num - 1);
    }
}
