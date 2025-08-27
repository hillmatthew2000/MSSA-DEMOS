namespace LINQDemo;

class Program 

{

    static void Main()
    {
        string[] names = { "Alice", "Bob", "Charlie" };
        IEnumerable<string> filteredNames = names.Where(n => n.Length >= 4);
        
        foreach (string n in filteredNames)
        {
            Console.WriteLine(n);
        }
    }

}