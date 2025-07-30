namespace Tester;
class Program
{
    static void Main(string[] args)
    {
        ExampleClass example = new ExampleClass(42, "Hello World");
        example.DisplayInfo();
        example.Property1 = 100;
        example.Property2 = "Updated String";
        example.DisplayInfo();
    }


}
public class ExampleClass
{
    //Fields -use case: to store data that should not be directly accessible from outside the class
    int field1;
    string field2;

    //Properties - use case: to provide controlled access to the fields
    public int Property1 { get; set; }
    public string Property2 { get; set; }

    //Constructor - use case: to initialize the properties when an instance of the class is created
    public ExampleClass(int property1, string property2)
    {
        Property1 = property1;
        Property2 = property2;
    }

    //Methods - use case: to define behaviors or actions that the class can perform
    public void DisplayInfo()
    {
        Console.WriteLine($"Property1: {Property1}, Property2: {Property2}");
    }
}