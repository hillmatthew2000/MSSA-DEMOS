using System;

namespace Subscription;

class Program
{
    static void Main()
    {
        Random random = new Random();
        int daysUntilExpiration = random.Next(12);
        int discountPercentage = 0;

        daysUntilExpiration = 2;

        if (daysUntilExpiration == 0)
        {
            Console.WriteLine("Your subscription has expired.");
        }
        else if (daysUntilExpiration == 1)
        {
            discountPercentage = 20;
            Console.WriteLine($"Your subscription expires within a day!\nRenew now and save {discountPercentage}%!");
        }
        else if (daysUntilExpiration <= 5)
        {
            discountPercentage = 10;
            System.Console.WriteLine($"Your subscription expires {daysUntilExpiration} days. \nRenew now and save {discountPercentage} % ! \nThat's enough to buy a pack of gum!");
        }
        else if (daysUntilExpiration <= 10)
        {
            Console.WriteLine("Your subscription will expire soon. Renew now!");
        }
    }
}