using System.Collections;

namespace SortedListDemo;

class Program
{
    static void Main(string[] args)
    {
        SortedList productPrices = new SortedList();

        productPrices.Add(102, 19.99);
        productPrices.Add(101, 6.99);
        productPrices.Add(103, 14.99);

        Console.WriteLine("Product prices (sorted by key):");
        foreach (DictionaryEntry entry in productPrices)
        {
            Console.WriteLine($"{entry.Key}: ${entry.Value}");
        }

        double price = (double)productPrices[102];
        Console.WriteLine($"\nPrice of product 102: ${price}");

    }
}
