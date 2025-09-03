using System.Collections;

namespace HashTableDemo;

class Program
{
    static void Main()
    {
        Hashtable table = new Hashtable();

        table["age"] = 30;
        table["price"] = 19.99;
        table["status"] = true;

        table.Add("type", "vintage");

        int age = (int)table["age"];
        double price = (double)table["price"];
        bool status = (bool)table["status"];

        System.Console.WriteLine($"Age: {age}");
        System.Console.WriteLine($"Price: {price}");
        System.Console.WriteLine($"Status: {status}");
        System.Console.WriteLine($"Type: {table["type"]}");
    }
}
