namespace DynamicDemo;

class Program
{
    static void Main(string[] args)
    {
        dynamic message = "Hello world";
        System.Console.WriteLine(message.ToUpper());

        message = 123;
        Console.WriteLine(message + 1); //this displays 124
        Console.WriteLine(message.ToUpper()); //this will compile however an undhandled exception is thrown

    }
}
