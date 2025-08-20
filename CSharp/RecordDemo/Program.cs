namespace RecordDemo;

class Program
{
    record Person(string Name, int Age);
    static void Main()
    {
        Person person1 = new("Alice", 30);
        Person person2 = new("Alice", 30);

        //structural equality
        if (person1 == person2)
        {
            Console.WriteLine("Both persons are equal.");
        }
        else
        {
            Console.WriteLine("Persons are not equal.");
        }

        // reference equality
        if (ReferenceEquals(person1, person2))
        {
            Console.WriteLine("Both persons refer to the same instance.");
        }
        else
        {
            Console.WriteLine("Persons refer to different instances.");
        }
    }
}
