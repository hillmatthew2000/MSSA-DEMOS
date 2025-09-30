namespace MergeSort;

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = { 7, 4, 10, 5, 1, 8 };
        Display(numbers);

        MergeSort(numbers);
        Display(numbers);
    }

    static void Display(int[] nums)
    {
        Console.Write(string.Join(", ", nums));
        Console.WriteLine();
    }

    static void MergeSort(int[] nums)
    {
        int left = 0;
        int right = nums.Length - 1;
        int mid = nums.Length / 2;
        if (left < mid)
        {
            
        }
    }


}
