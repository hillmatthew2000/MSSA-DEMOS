namespace Tester;

class Program
{
    static void Main(string[] args)
    {
        string input = "yes";
        bool saidYes = (input.ToUpper() == "YES");
        Console.WriteLine(saidYes);
    }
}
