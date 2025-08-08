namespace Tester;

class Program
{
    static void Main(string[] args)
    {

    }
}

interface IPersonName
{
    string FirstName { get; set; }
    string LastName { get; set; }
    void GetFullName();

}

public class CustomPerson : IPersonName
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public void GetFullName()
    {
        Console.WriteLine($"Full Name: {FirstName} {LastName}");
    }
}
