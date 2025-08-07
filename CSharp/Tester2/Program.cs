using System.Security.Cryptography.X509Certificates;

namespace Tester2;

class Program
{
    static void Main(string[] args)
    {
        string[] texts = { "You have much to", "Today is a day to", "Whatever work you do", "This is an ideal time to" };
        string[] good = { "look forward to.", "try new things!", "is likely to succeed.", "accomplish your dreams!" };
        string[] bad = { "fear.", "avoid major decisions.", "may have unexpected outcomes.", "re-evaluate your life." };
        string[] neutral = { "appreciate.", "enjoy time with friends.", "should align with your values.", "get in tune with nature." };

        TellFortune(texts, good, bad, neutral);
    }

    public static void TellFortune(string[] texts, string[] good, string[] bad, string[] neutral)
    {
        Random number = new Random();
        int randomNumber = number.Next(1, 4);
        string[] tone;

        if (randomNumber == 1)
        {
            tone = good;
        }
        else if (randomNumber == 2)
        {
            tone = bad;
        }
        else
        {
            tone = neutral;
        }

        // Combine texts with selected tone
        for (int i = 0; i < texts.Length; i++)
        {
            Console.Write($"{texts[i]} {tone[i]}");
        }
    }

    // string[][] tones = { good, bad, neutral };
    //     TellFortune(texts, tones);
    // }

    //  public static void TellFortune(string[] texts, string[][] tones)
    // {
    //     Random randomNum = new Random();
    //     int randomNumber = randomNum.Next(0, 3);
    //     int i = 0;

    //     foreach (string text in texts)
    //     {
    //         System.Console.Write($"{text} {tones[randomNumber][i]} ");
    //         i++;
    //     }
    // }
}
