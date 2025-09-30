namespace Tester;

class Program
{
    static void Main(string[] args)
    {
        int[] studentIDs = { 110, 20, 30, 100, 50, 90, 70, 80, 190, 200 };
        Display(studentIDs);

        int result = Search(studentIDs, GetUserInput());
        DisplaySearchResult(result);
    }

    static void Display(int[] studentIDs)
    {
        Console.Write("Original Array: ");
        Console.WriteLine(string.Join(", ", studentIDs));
    }

    static int GetUserInput()
    {
        Console.WriteLine("Enter a student ID");
        bool isValid = int.TryParse(Console.ReadLine(), out int value);
        if (!isValid)
            throw new InvalidExpressionException("Invalid input");
        return value;
    }

    static int Search(int[] studentIDs, int searchID)
    {
        foreach (int id in studentIDs)
            if (searchID == id)
                return Array.IndexOf(studentIDs, id);
        return -1;
    }

    static void DisplaySearchResult(int result)
    {
        if (result == -1)
            Console.WriteLine("Element missing from the array");
        else
            Console.WriteLine($"Element is located at the following index: {result}");
    }

}


 

