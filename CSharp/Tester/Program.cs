using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Tester;

class Program
{
    static void Main(string[] args)
    {
        Address ip1 = new Address();
        ip1.DisplayResults(ip1.Validation("192.168.1.255"));
    }
}

public class Address
{
    public bool Validation(string ipAddress)
    {
        bool isValid = true;
        string[] numbers = ipAddress.Split(".");
        if (numbers.Length != 4)
        {
            isValid = false;
            return isValid;
        }
        else if (numbers.Length == 4)
        {
            foreach (string num in numbers)
            {
                int wordToNumber = int.Parse(num);
                if (num.Length > 1 && num[0] == 0)
                {
                    isValid = false;
                    return isValid;
                }
                else if (wordToNumber < 0 || wordToNumber > 255)
                {
                    isValid = false;
                    return isValid;
                }
            }
        }
        return isValid;

    }
    public void DisplayResults(bool isValid)
    {
        if (isValid == true)
        {
            Console.WriteLine("That is a valid IP Address");
        }
        else
        {
            Console.WriteLine("This is not a valid IP Address");
        }
    }
}