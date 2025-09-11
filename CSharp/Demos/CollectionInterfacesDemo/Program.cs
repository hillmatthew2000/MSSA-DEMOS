using System.Collections.ObjectModel;

namespace CollectionInterfacesDemo;

class Program
{
    static void Main(string[] args)
    {
        //Notice there are several collection types and interfaces to use
        List<int> numbersList1 = new List<int>();
        Collection<int> numbersList2 = new Collection<int>(numbersList1);
        ICollection<int> numbersList3 = new List<int>();
        IEnumerable<int> numbersList4 = new List<int>();

        //Here is how to find out what interfaces a type implements 
        Type listType = typeof(List<int>);
        Type[] interfaces = listType.GetInterfaces();

        Console.WriteLine("Interfaces implemented by List<int>:");
        foreach (Type iface in interfaces)
        {
            Console.WriteLine(iface.FullName);
        }
    }
}
