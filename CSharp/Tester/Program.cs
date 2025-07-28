using System.Buffers;
using System.Net;
using System.Threading.Channels;

namespace Tester;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter the grid dimension");
        string userInput = Console.ReadLine();
        int gridDimensions = int.Parse(userInput);

        CreateGrid(gridDimensions);
    }

    public static void CreateGrid(int gridDimensions)
    {
        char xLetter = 'X';
        char oLetter = 'O';
        for (int i = 0; i < gridDimensions; i++)
        {
            for (int j = 0; j < gridDimensions; j++)
            {
                if ((i + j) % 2 == 0)
                {
                    Console.Write(xLetter);
                }
                else
                {
                    Console.Write(oLetter);
                }
            }
            Console.WriteLine();
        }
    }

}