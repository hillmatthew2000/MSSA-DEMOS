namespace LinearSearch;

class Program
{
    static void Main(string[] args)
    {
        int[] arr = { 10, 2, 34, 4, 5, 15, 23 };
        int target = 15;
        int result = LinearSearch(arr, target);
        if (result != -1)
        {
            Console.WriteLine($"Element found at index: {result}");
        }
        else
        {
            Console.WriteLine("Element not found in the array.");
        }
    }

    static int LinearSearch(int[] arr, int target)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == target)
            {
                return i;
            }
        }
        return -1;
    }
}
