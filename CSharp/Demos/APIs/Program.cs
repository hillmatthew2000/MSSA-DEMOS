namespace BlockingExample;
class Program
{
    static void Main(string[] args)
    {
        using (HttpClient client = new HttpClient())
        {
            string[] urls =
            {
                "https://petstore.swagger.io/v2/pet/findByStatus?status=available",
                "https://petstore.swagger.io/v2/pet/findByStatus?status=pending",
                "https://petstore.swagger.io/v2/pet/findByStatus?status=sold"
            };
            var start = DateTime.Now;

            foreach (var url in urls)
            {
                HttpResponseMessage response = client.GetAsync(url).Result;
                string responseBody = response.Content.ReadAsStringAsync().Result;

                var pets = JsonSerializer.Deserialize<List<Pet>>(responseBody);
                Console.WriteLine($"{url} returned {pets?.Count} pets");
                if (pets != null && pets.Count > 0)
                {
                    var pet = pets[0];
                    Console.WriteLine($"Example Id: {pet.id}, Name: {pet.name}, Category: {pet.category?.name}, Tags: {string.Join(", ", pet.tags?.ConvertAll(t => t.name) ?? new List<string?>())}");
                }
            }
            var end = DateTime.Now;
            Console.WriteLine($"Total time(blocking): {(end - start).TotalSeconds:F2} seconds");
        }
    }
}

public class Pet
{
    public long id { get; set; }
    public string? name { get; set; }
    public string? status { get; set; }
    public Category? category { get; set; }
    public List<string>? photoUrls { get; set; }
    public List<Tag>? tags { get; set; }
    
}

public class Category
{
    public long id { get; set; }
    public string? name{ get; set; }
}

public class Tag
{
    public long id { get; set; }
    public string? name { get; set; }
}


