namespace SelectionSort;

class Program
{
    static void Main(string[] args)
    {
        int[] arr = { 7, 4, 10, 5, 1, 8 };
 
        Console.WriteLine("Original array");
        foreach (int value in arr)
        {
            Console.WriteLine(value + " ");
        }
 
        for (int i = 0; i < arr.Length - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < arr.Length; j++)
            {
                if (arr[j] < arr[minIndex])
                    minIndex = j;
            }
            int temp = arr[minIndex];
            arr[minIndex] = arr[i];
            arr[i] = temp;
        }
        Console.WriteLine("\nSorted array");
        foreach (int value in arr)
        {
            Console.WriteLine(value + " ");
        }
    }
}