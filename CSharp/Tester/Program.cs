using System.Buffers;
using System.Net;
using System.Threading.Channels;

namespace Tester;

class Program
{
    static void Main(string[] args)
    {
        for (int i = 1; i <= 100; i++)
        {
            if ((i % 3 == 0) && (i % 5 == 0))
            {
                Console.WriteLine($"{i} FizzBuzz");
            }
            else if (i % 3 == 0)
            {
                Console.WriteLine($"{i} Fizz");
            }
            else if (i % 5 == 0)
            {
                Console.WriteLine($"{i} Buzz");
            }
        }
    }

}