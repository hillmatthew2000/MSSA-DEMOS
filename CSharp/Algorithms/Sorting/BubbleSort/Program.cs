namespace BubbleSort;

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = { 5, 2, 8, 3, 9 };
        Display(numbers);

        BubbleSort(numbers);
        Display(numbers);
    }

    static void Display(int[] nums)
    {
        Console.Write(string.Join(", ", nums));
        Console.WriteLine();
    }

    static void BubbleSort(int[] list)
    {
        bool swapped;
        int n = list.Length;
 
        for (int i = 0; i < n - 1; i++)
        {
            swapped = false;
 
            for (int j = 0; j < n - i - 1; j++)
            {
                if (list[j] > list[j + 1])
                {
                    SwapNumbers(ref list[j], ref list[j + 1]);
                    swapped = true;
                }
            }
 
            if (!swapped)
                break;
        }
 
    }

    static void SwapNumbers(ref int x, ref int y)
    {
        int temp = x;
        x = y;
        y = temp;
    }
}