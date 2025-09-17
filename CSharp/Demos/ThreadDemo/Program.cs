namespace ThreadDemo;

class Program
{
    static void Main()
    {
        // === Thread.Start and Thread.Join ===
        Console.WriteLine("Starting Thread.Start and Join Demo...");
        Thread t = new Thread(WriteY);
        t.Start();

        for (int i = 0; i < 1000; i++)
            Console.Write("x");

        bool finished = t.Join(500);
        Console.WriteLine($"\nThread {(finished ? "completed" : "did not complete")} within 500ms.");

        // === Thread.Sleep ===
        Console.WriteLine("\nStarting Thread.Sleep Demo...");
        Console.WriteLine("Sleeping for 1 second...");
        Thread.Sleep(1000);
        Console.WriteLine("Yielding CPU with Sleep(0)...");
        Thread.Sleep(0);
        Console.WriteLine("Thread.Sleep Demo Done!");
    }

    static void WriteY()
    {
        for (int i = 0; i < 1000; i++)
            Console.Write("y");
    }
}