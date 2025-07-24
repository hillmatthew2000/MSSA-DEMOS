namespace Tester;

class Program
{
    static void Main(string[] args)
    {
        Random coin = new Random();
        int coinToss = coin.Next(1, 3);
        Console.WriteLine($"You flipped: {(coinToss == 1 ? "Heads" : "Tails")}!");
        // Person p1 = new Person("Bob");
        // Person p2 = new Person("Bob");
        // Person p3 = p1;

        // string s1 = "hello";
        // string s2 = "hello";
        // string s3 = new string("hello".ToCharArray());
        // Console.WriteLine(s1 == s2);
        // System.Console.WriteLine(s1 == s3);

        // bool isLoggedIn = false;
        // if (!isLoggedIn)
        // Console.WriteLine("log in first");

        // int score = 85;
        // Console.WriteLine($"Grade: {(score >= 90 ? "A" : score > 80 ? "B" : "C")}");
    }
}

public class Person
{
    public string Name { get; set; }

    public Person(string name)
    {
        this.Name = name;
    }
}