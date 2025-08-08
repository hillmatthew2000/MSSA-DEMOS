namespace FortuneTeller;

class Program
{
    static void Main(string[] args)
    {
        string[] texts = { "You have much to", "Today is a day to", "Whatever work you do", "This is an ideal time to" };
        string[] good = { "look forward to.", "try new things!", "is likely to succeed.", "accomplish your dreams!" };
        string[] bad = { "fear.", "avoid major decisions.", "may have unexpected outcomes.", "re-evaluate your life." };
        string[] neutral = { "appreciate.", "enjoy time with friends.", "should align with your values.", "get in tune with nature." };

        TellFortune(texts, good, bad, neutral);

        // string[][] tones = { good, bad, neutral };
        // TellFortune(texts, tones);
    }

    static void TellFortune(string[] texts, string[] good, string[] bad, string[] neutral)
    {
        Random random = new Random();
        int luck = random.Next(1, 4);

        string[] fortune = luck == 1 ? good : luck == 2 ? bad : neutral;

        Console.WriteLine("A fortune teller whispers the following words:");

        for (int i = 0; i < texts.Length; i++)
        {
            Console.Write($"{texts[i]} {fortune[i]}");
        }
    }

    //  public static void TellFortune(string[] texts, string[][] tones)
    // {
    //     Random randomNum = new Random();
    //     int luck = randomNum.Next(0, 3);
    //     int i = 0;

    //     foreach (string text in texts)
    //     {
    //         System.Console.Write($"{text} {tones[luck][i]} ");
    //         i++;
    //     }
    // }
}
