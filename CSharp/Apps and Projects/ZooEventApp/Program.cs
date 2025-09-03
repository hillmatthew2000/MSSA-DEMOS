namespace ZooEventApp;

class Program
{
    private static readonly Random random = new();

    private static readonly string[] pettingZoo =
    [
        "alpacas", "capybaras", "chickens", "ducks", "emus",
        "geese", "goats", "iguanas", "kangaroos", "lemurs",
        "llamas", "macaws", "ostriches", "pigs", "ponies", "rabbits", "sheep", "tortoises"
    ];
    
    static void Main()
    {
        Console.WriteLine("Enter your school name.");
        string? input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Invalid input.");
            return;
        }
        string[] randomAnimals = RandomizeAnimals(pettingZoo);
        GroupOrganizer(input, randomAnimals);
    }

    // Randomize Animals
    static string[] RandomizeAnimals(string[] anyArray)
    {
        return anyArray.OrderBy(_ => random.Next()).ToArray();
    }

    static void GroupOrganizer(string school, string[] randomAnimals)
    {
        school = school.ToLower().Trim();
        int groups = school switch
        {
            "school a" => 6,
            "school b" => 3,
            "school c" => 2,
            _ => throw new InvalidOperationException("School not recognized.")
        };
        int animalsPerGroup = pettingZoo.Length / groups;
        Console.WriteLine($"\nSchool: {school.ToUpper()}");
        MakeGroups(groups, animalsPerGroup, randomAnimals);
    }
    static void MakeGroups(int groups, int animalsPerGroup, string[] randomAnimals)
    {
        var studentGroups = randomAnimals
            .Select((animal, index) => new { animal, group = index % groups })
            .GroupBy(x => x.group)
            .OrderBy(g => g.Key)
            .Select(g => g.Select(x => x.animal).ToList())
            .ToList();

        // Print animal groups
        for (int i = 0; i < studentGroups.Count; i++)
        {
            var group = studentGroups[i];
            Console.WriteLine($"Group {i + 1}: {string.Join(", ", group)}");
        }
    }
    }
