namespace DQQDemo;

class Program
{
    static void Main()
    {
        // string[] names = { "Alice", "Bob", "Charlie" };
        Type arrayType = typeof(string[]);
        Type[] interfaces = arrayType.GetInterfaces();

        Console.WriteLine($"Interfaces implemented by string[]: ");
        foreach (Type iface in interfaces)
        {
            Console.WriteLine($" - {iface.FullName}");
        }
    }
}