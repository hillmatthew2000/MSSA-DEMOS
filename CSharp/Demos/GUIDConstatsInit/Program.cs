namespace GUIDConstantsInit;

class Program
{
    const decimal TaxRate = 0.075m;
    static void Main()
    {
        var e1 = new Example();
        var e2 = new Example();

        Console.WriteLine($"e1.Id: {e1.Id}");
        Console.WriteLine($"e2.Id: {e2.Id}");

        var p1 = new PersonWithSet { Name = "Alice" };
        Console.WriteLine($"p1.Name: {p1.Name}");
        p1.Name = "Bob";
        Console.WriteLine($"p1.Name: {p1.Name}");
        var p2 = new PersonWithInit { Name = "Karen" };
        Console.WriteLine($"p2.Name: {p2.Name}");
        p2.Name = "Lily"; // This will cause a compile-time error
        Console.WriteLine($"p2.Name: {p2.Name}");
    }
 
}

public class Example
{
    public readonly Guid Id = Guid.NewGuid();

    public Example()
    {

    }
}

public class PersonWithSet
{
    public string Name { get; set; }
}

public class PersonWithInit
{
    public string Name { get; init; }
}
