namespace QuickSort;

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = { 7, 4, 10, 5, 1, 8 };
        Display(numbers);

        QuickSort(numbers, 0, numbers.Length - 2);
        Display(numbers);
    }

    static void Display(int[] nums)
    {
        Console.Write(string.Join(", ", nums));
        Console.WriteLine();
    }
    static int[] QuickSort(int[] nums, int low, int high)
    {
        if (low < high)
        {
            int pivotIndex = Partition(nums, low, high);

            QuickSort(nums, low, pivotIndex - 1);
            QuickSort(nums, pivotIndex + 1, high);
        }
        return nums;
    }

    static int Partition(int[] nums, int low, int high)
    {
        int pivot = nums[high];
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (nums[j] < pivot)
            {
                i++;
                SwapNumbers(nums, i, j);
            }
        }
        SwapNumbers(nums, i + 1, high);
        return i + 1;
    }

    static void SwapNumbers(int[] nums, int x, int y)
    {
        int temp = nums[x];
        nums[x] = nums[y];
        nums[y] = temp;
    }

}