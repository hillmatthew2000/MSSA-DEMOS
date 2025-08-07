namespace IpAddress;

class Program
{
    static void Main(string[] args)
    {
        Ipv4Address.Address();
    }
}

public class Ipv4Address
{
    static string IpAddress;

    public static void Address()
    {
        Console.WriteLine("Enter a valid ipv4 ip address.");
        IpAddress = Console.ReadLine();
        string[] numbers = IpAddress.Split(".");
        DisplayResults(numbers);
    }
    static bool ValidateLength(string[] numbers)
    {
        return numbers.Length == 4;
    }

    static bool ValidateZeros(string[] numbers)
    {
        foreach (string number in numbers)
        {
            if (number.Length > 1 && number.StartsWith("0"))
            {
                return false;
            }
            else continue;
        }
        return true;
    }

    static bool ValidateRange(string[] numbers)
    {
        foreach (string number in numbers)
        {
            if (!int.TryParse(number, out int result) || result > 255 || result < 0)
            {
                return false;
            }
            else
                continue;
        }
        return true;
    }
    static void DisplayResults(string[] numbers)
    {
        if (ValidateLength(numbers) && ValidateRange(numbers) && ValidateZeros(numbers))
        {
            Console.WriteLine("That is a valid IP Address");
        }
        else
        {
            Console.WriteLine("This is not a valid IP Address");
        }
    }
}