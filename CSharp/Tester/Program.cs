namespace Tester;

class Program
{
    static void Main(string[] args)
    {
        //     string pangram = "The quick brown fox jumps over the lazy dog";
        //     Console.WriteLine(string.Join(" ", pangram.Split(' ').Select(word => new string(word.Reverse().ToArray()))));

        string orderStream = "B123,C234,A345,C15,B177,G3003,C235,B179";
        string[] orderIds = orderStream.Split(',');
        Array.Sort(orderIds);
        foreach (string orderId in orderIds)
        {
            if (orderId.Length != 4)
            {
                Console.WriteLine($"Invalid order ID: {orderId}");
                continue;
            }
            Console.WriteLine(orderId);
        }
    }
}


