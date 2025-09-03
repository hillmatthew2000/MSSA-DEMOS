using System;
using ExtensionMethodDemo;

namespace ExtensionMethodDemo
{
    public static class StringHelper
    {
        public static bool IsCapitalized(this string s)
        {
            if (string.IsNullOrEmpty(s)) return false;
            return char.IsUpper(s[0]);
        }
    }
}

class Program
{

    static void Main(string[] args)
    {
        string City1 = "Berlin";
        string City2 = "Amsterdam";
        string City3 = "London";

        Console.WriteLine($"{City1} is capitalized: {City1.IsCapitalized()}");
        Console.WriteLine($"{City2} is capitalized: {City2.IsCapitalized()}");
        Console.WriteLine($"{City3} is capitalized: {City3.IsCapitalized()}");
    }
}
