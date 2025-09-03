namespace ExceptionHandlingDemo;

class Program

{

    static void Main(string[] args)
    {
        //ArrayTypeMismatchException
        try
        {
            object[] array = new string[2];
            array[0] = 123;
        }
        catch (ArrayTypeMismatchException)
        {
            Console.WriteLine("Caught ArrayTypeMismatchException");
        }

        //DivideByZeroException
        try
        {
            int x = 0;
            int result = 10 / x;
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("Caught DivideByZeroException");
        }

        //FormatException
        try
        {
            string input = "abc";
            int number = int.Parse(input);
        }
        catch (FormatException)
        {
            Console.WriteLine("Caught FormatException");
        }

        //IndexOutOfRangeException
        try
        {
            int[] numbers = new int[5];
            int invalidValue = numbers[10];
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("Caught IndexOutOfRangeException");
        }

        //InvalidCastException
        try
        {
            object obj = "Hello";
            int num = (int)obj;
        }
        catch (InvalidCastException)
        {
            Console.WriteLine("Caught InvalidCastException");
        }

        //OverflowException
        try
        {
            int max = int.MaxValue;
            int result = checked(max + 1);
        }
        catch (OverflowException)
        {
            Console.WriteLine("Caught OverflowException");
        }

        //NullReferenceException
        try
        {
            string? str = null;
            int length = str.Length;
        }
        catch (NullReferenceException)
        {
            Console.WriteLine("Caught NullReferenceException");
        }

        //StackOverflowException
        try
        {
            int max = int.MaxValue;
            int result = checked(max + 1);
        }
        catch (StackOverflowException)
        {
            Console.WriteLine("Caught StackOverflowException");
        }

        //How to handle an unknown Exception
        try
        {
            //Code that may throw an exception
        }
        catch (Exception ex)
        {
            Console.WriteLine("An exception has occured");
            Console.WriteLine("Type (full): " + ex.GetType());
            Console.WriteLine("Type (name only): " + ex.GetType().Name);
            Console.WriteLine("Message: " + ex.Message);
        }
    }


//     static void Main(string[] args)
//     {
//         Console.WriteLine("Start of Main");

    //         try
    //         {
    //             Console.WriteLine("Entered outer try block");
    //             try
    //             {
    //                 Console.WriteLine("Entered inner try block");

    //                 int x = 0;
    //                 int result = 10 / x;

    //                 Console.WriteLine("This line will not be executed due to exception above.");
    //             }
    //             finally
    //             {
    //                 Console.WriteLine("Inner finally block executed.");
    //             }
    //         }
    //         catch (DivideByZeroException)
    //         {
    //             Console.WriteLine("Caught DividByZeroException in outer catch block.");
    //         }
    //         finally
    //         {
    //             Console.WriteLine("Outer finally block executed.");
    //         }
    //         Console.WriteLine("End of Main");
    //     }
}