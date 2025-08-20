using System.Collections;
using System.Net.Quic;

namespace ArrayListDemo;

class Program
{
    static void Main()
    {
        ArrayList list = new ArrayList();
        list.Add("Apple");
        list.Add("Banana");
        list.Add(123);
        list.Add(true);

        Console.WriteLine("Access by index:");
        Console.WriteLine("First item: " + list[0]);
        Console.WriteLine("Second item: " + list[1]);

        list[1] = "Orange";
        list.Remove("Apple");
        list.Insert(1, "Grapes");

        Console.WriteLine("\nCurrentArrayListContents");
        for (int i = 0; i < list.Count; i++)
        {
            Console.WriteLine($"Item at index {i}: {list[i]}");
        }

        list.RemoveAt(1);

        Console.WriteLine("\nAfter RemoveAt(1)");
        for (int i = 0; i < list.Count; i++)
        {
            Console.WriteLine($"Item at index {i}: {list[i]}");
        }
    }
}
