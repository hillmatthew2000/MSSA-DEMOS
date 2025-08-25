using System.Reflection;

namespace tester2;

class Program

{
    static void Main(string[] args)
    {
        Console.WriteLine("Start of Main");

        try
        {
            Console.WriteLine("Entered outer try block");
            try
            {
                Console.WriteLine("Entered inner try block");

                int x = 0;
                int result = 10 / x;

                Console.WriteLine("This line will not be executed due to exception above.");
            }
            finally
            {
                Console.WriteLine("Inner finally block executed.");
            }
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Caught DividByZeroException in outer catch block.");
        }
        finally
        {
            Console.WriteLine("Outer finally block executed.");
        }
        Console.WriteLine("End of Main");
    }
}
