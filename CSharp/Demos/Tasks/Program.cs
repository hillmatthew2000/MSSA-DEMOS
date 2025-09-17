namespace Tasks;

class Program
{
    static void Main()
    {
        // === Thread Pool with Task.Run ===
        Console.WriteLine("Starting Thread Pool with Task.Run...");
        Task poolTask = Task.Run(() =>
        {
            Console.WriteLine("Running on thread pool...");
            Thread.Sleep(1000); // Simulate work
            Console.WriteLine("Task completed.");
        });
        Console.WriteLine("Main thread continues...");
        poolTask.Wait();
        Console.WriteLine("Thread Pool Done.");

        // === Task with Return Value ===
        Console.WriteLine("\nStarting Task Return...");
        Task<int> primeNumberTask = Task.Run(() =>
            Enumerable.Range(2, 10000)
                      .Count(n => Enumerable.Range(2, (int)Math.Sqrt(n) - 1)
                                            .All(i => n % i > 0)));
        Console.WriteLine("Task running...");
        Console.WriteLine("Number of primes: " + primeNumberTask.Result);

        // === Task Continuation ===
        Console.WriteLine("\nStarting Task Continuation...");
        Task<int> continuationTask = Task.Run(() =>
            Enumerable.Range(2, 10000)
                      .Count(n => Enumerable.Range(2, (int)Math.Sqrt(n) - 1)
                                            .All(i => n % i > 0)));
        var awaiter = continuationTask.GetAwaiter();
        awaiter.OnCompleted(() =>
        {
            int result = awaiter.GetResult();
            Console.WriteLine("Number of primes (via continuation): " + result);
        });
        Console.WriteLine("Main thread continues...");
        Thread.Sleep(2000); // Simulate waiting for continuation

        // === Task.Delay ===
        Console.WriteLine("\nStarting Task.Delay...");
        var delayAwaiter = Task.Delay(1000).GetAwaiter();
        delayAwaiter.OnCompleted(() =>
        {
            Console.WriteLine("Done after 1 second delay.");
        });
        Console.WriteLine("Main thread is not blocked.");
        Thread.Sleep(1500); // Simulate waiting for delay
    }
}