using System.Data;

namespace tester2;

class Program
{
    static void Main()
    {
        int[] isbnNumbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        int target = GetUserInput();
        DisplaySearchResults(BinarySearch(isbnNumbers, target));


    }

    static int BinarySearch(int[] nums, int target)
    {
        int lowerBound = 0;
        int upperBound = nums.Length - 1;
        
        while (lowerBound <= upperBound)
        {
            int mid = (upperBound + lowerBound) / 2;
            if (nums[mid] > target)
                upperBound = mid - 1;
            else if (nums[mid] < target)
                lowerBound = mid + 1;
            else
                return mid;
        }
        return -1;
    }

    static void DisplaySearchResults(int result)
    {
        if (result == -1)
            Console.WriteLine("ISBN not found");
        else
            Console.WriteLine($"ISBN number found at index: {result}");
    }

    static int GetUserInput()
    {
        Console.WriteLine("Enter a ISBN number to search for.");

        bool isValid = int.TryParse(Console.ReadLine(), out int value);
        if (!isValid) throw new InvalidExpressionException("Invalid input");
        return value;      
    }
}