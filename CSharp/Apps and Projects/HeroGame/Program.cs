namespace HeroGame;

class Program
{
    static void Main(string[] args)
    {
        
        Console.WriteLine("Enter your Hero's name!");
        string heroName = Console.ReadLine();

        Console.WriteLine("Enter the Monster's name!");
        string monsterName = (Console.ReadLine());

        Console.Clear();
        
        int heroHealth = 10;
        int monsterHealth = 10;
        Random attackvalue = new Random();

        do
        {
            int heroAttack = attackvalue.Next(1, 5);
            monsterHealth -= heroAttack;
            Console.WriteLine($"{heroName} has struck {monsterName} for {heroAttack} damage! {monsterName} has {monsterHealth} remaining health!");

            if (monsterHealth <= 0)
                break;

            int monsterAttack = attackvalue.Next(1, 5);
            heroHealth -= monsterAttack;
            Console.WriteLine($"{monsterName} has struck {heroName} for {monsterAttack} damage! {heroName} has {heroHealth} remaining health!");
        } while (heroHealth > 0 && monsterHealth > 0);

        if (heroHealth > 0)
        {
            Console.WriteLine($"{heroName} has prevailed!!!");
        }
        else
        {
            Console.WriteLine($"{monsterName} has vanquished you!");
        }
    }
}