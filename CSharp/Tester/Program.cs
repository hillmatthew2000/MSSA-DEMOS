namespace Tester;

class Program
{
    static void Main(string[] args)
    {
        // //Variables
        // string? input;
        // int result;
        // bool isValid;

        // //Do-While for checking user input and assigning it to result var
        // do
        // {
        //     Console.WriteLine("Enter a number");
        //     input = Console.ReadLine();
        //     isValid = int.TryParse(input, out result);
        // } while (!isValid || result < 5 || result > 10);

        // Console.Clear();
        // Console.WriteLine($"{result} is a valid number!");


        string? roleName = Console.ReadLine();

        // do
        // {
        //     Console.WriteLine("Enter your role name");
        //     roleName = Console.ReadLine().Trim().ToLower();
        // } while ((roleName != "administrator") &&
        //  (roleName != "manager") && (roleName != "user"));

        // Console.Clear();
        // Console.WriteLine($"Access Granted, Welcome {roleName}!");

        string[] myString = new string[2] { "I like pizza. I like roast chicken. I like salad", "I like all three of the menu choices" };
        
        foreach (string sentence in myString)
        {
            string remaining = sentence;
            int periodLocation;
            do
            {
                periodLocation = remaining.IndexOf(".");
                if (periodLocation > -1)
                {
                    Console.WriteLine("Sentence: " + remaining.Remove(periodLocation));
                    remaining = remaining.Substring(periodLocation + 1).TrimStart(' ');
                }
                else if (remaining.Length > 0)
                {
                    Console.WriteLine("Sentence: " + remaining.TrimStart());
                }
                
            } while (periodLocation > -1);
        }
    }
}