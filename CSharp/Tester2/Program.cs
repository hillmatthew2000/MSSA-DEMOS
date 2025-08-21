using System.Collections;
using System.Globalization;

namespace Tester2;

class Program
{

    static void Main()
    {
        Hashtable ngPhoneBook = new Hashtable();
        ngPhoneBook["Alice"] = "123-4567";
        ngPhoneBook["Bob"] = "987-6543";
        ngPhoneBook["Charlie"] = "555-0000";

        Console.WriteLine("Phone book entries:");
        foreach (DictionaryEntry entry in ngPhoneBook)
        {
            Console.WriteLine($"{entry.Key}: {entry.Value}");
        }
        Dictionary<string, string> phoneBook = new Dictionary<string, string>();
        phoneBook["Alice"] = "123-4567";
        phoneBook["Bob"] = "987-6543";
        phoneBook["Charlie"] = "555-0000";

        Console.WriteLine("Phone book entries:");
        foreach (var entry in phoneBook)
        {
            Console.WriteLine($"{entry.Key}: {entry.Value}");
        }
    }
    // static void Main()
    // {
    //     ArrayList ngNumbers = new ArrayList();
    //     ngNumbers.Add(10);
    //     int ngX = (int)ngNumbers[0];
    //     Console.WriteLine($"ngX is {ngX}");

    //     List<int> gNumbers = new List<int>();
    //     gNumbers.Add(10);
    //     int gX = gNumbers[0];
    //     Console.WriteLine($"gX is {gX}");

    // }

}
 