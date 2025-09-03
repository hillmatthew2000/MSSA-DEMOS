namespace LINQDemo;

class Program 

{

    static void Main()
    {
        string[] names = { "Alice", "Bob", "Charlie" };

        // IEnumerable<string> filteredNames = from n in names
        //                     where n.Length >= 4
        //                     select n;

        // IEnumerable<string> filteredNames = names.Where(n => n.Length >= 4);

        IEnumerable<string> filteredNames = names
        .Where(n => n.Contains("a"))
        .OrderBy(n => n.Length)
        .Select(n => n.ToUpper());

        foreach (string n in filteredNames)
        {
            Console.WriteLine(n);
        }

        int[] numbers = { 10, 9, 8, 7, 6 };
        IEnumerable<int> col1 = numbers.Take(3); //10, 9, 8
        IEnumerable<int> col2 = numbers.Skip(3); //7, 6
        IEnumerable<int> col3 = numbers.Reverse(); //6, 7, 8, 9, 10

        int firstNumber = numbers.First(); //10
        int lastNumber = numbers.Last(); //6
        int secondNumber = numbers.ElementAt(1); //9
        int someNumber = numbers.OrderBy(n => n).Skip(1).First(); //7

        //Methods that return a single value like .count() and .First() use immediate query execution whereas methods that don't like .Contains() or OrderBy() use deferred execution.
        int count = numbers.Count(); //5
        int min = numbers.Min(); //6

        bool hasAnOddElement = numbers.Any(n => n % 2 != 0); //true

        int[] seq1 = { 1, 2, 3 };
        int[] seq2 = { 3, 4, 5 };
        var concatenated = seq1.Concat(seq2); //123345
        var unioned = seq1.Union(seq2); //12345
        var intersected = seq1.Intersect(seq2); //3
    }

}