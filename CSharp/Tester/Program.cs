namespace Tester;

class Program
{
    static void Main(string[] args)
    {
        string pangram = "The quick brown fox jumps over the lazy dog";
        Console.WriteLine(string.Join(" ", pangram.Split(' ').Select(word => new string(word.Reverse().ToArray()))));
    }
}

class Program2
{
    
}


