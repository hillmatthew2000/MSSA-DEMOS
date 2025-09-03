using System.Collections;

namespace BitArrayDemo;

class Program
{
    static void Main()
    {
        BitArray bits = new BitArray(5);

        bits[0] = true;
        bits[2] = true;

        Console.WriteLine("BitArray values:");
        for (int i = 0; i < bits.Count; i++)
        {
            Console.WriteLine($"Bit {i}: {bits[i]}");
        }

        bits.Not();
        Console.WriteLine("\nAfter NOT operation:");
        for (int i = 0; i < bits.Count; i++)
        {
            Console.WriteLine($"Bit {i}: {bits[i]}");
        }
    }
}
