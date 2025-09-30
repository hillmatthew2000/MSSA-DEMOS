namespace BinarySearch;

class Program
{
    static void Main()
    {
        // Entry point of the program
        int[] isbnNumbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        int target = GetUserInput();
        DisplaySearchResults(BinarySearch(isbnNumbers, target));

        int target2 = GetUserInput();
        DisplaySearchResults(BinarySearchRecursive(isbnNumbers, target2, 0, isbnNumbers.Length - 1));
    }

    // Performs iterative binary search on an array
    static int BinarySearch(int[] nums, int target)
    {
        int lowerBound = 0;
        int upperBound = nums.Length - 1;
        int mid = (upperBound + lowerBound) / 2;
        while (lowerBound <= upperBound)
        {
            if (nums[mid] == target)
                return mid;
            else if (nums[mid] > target)
            {
                upperBound = mid - 1;
                mid = (upperBound + lowerBound) / 2;
            }
            else if (nums[mid] < target)
            {
                lowerBound = mid + 1;
                mid = (upperBound + lowerBound) / 2;
            }
        }
        return -1;
    }

    // Performs recursive binary search on an array
    static int BinarySearchRecursive(int[] nums, int target, int lowerBound, int upperBound)
    {
        if (lowerBound > upperBound)
            return -1;
        int mid = (upperBound + lowerBound) / 2;

        if (nums[mid] == target)
            return mid;
        else if (nums[mid] > target)
            return BinarySearchRecursive(nums, target, lowerBound, mid - 1);
        else
            return BinarySearchRecursive(nums, target, mid + 1, upperBound);
    }

    // Displays the result of the search
    static void DisplaySearchResults(int result)
    {
        if (result == -1)
            Console.WriteLine("ISBN not found");
        else
            Console.WriteLine($"ISBN number found at index: {result}");
    }

    // Gets user input from the console
    static int GetUserInput()
    {
        Console.WriteLine("Enter a ISBN number to search for.");

        bool isValid = int.TryParse(Console.ReadLine(), out int value);
        if (!isValid) throw new ArgumentException("Invalid input");
        return value;
    }
}