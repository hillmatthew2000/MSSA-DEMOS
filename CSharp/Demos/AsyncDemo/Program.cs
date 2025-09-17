namespace AsyncDemo;

class Program
{
    static async Task Main()
    {
        // === Async/Await ===
        Console.WriteLine("Starting Async/Await Demo...");
        var backgroundTask = DoBackgroundWorkAsync();
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($"Main thread working... {i}");
            await Task.Delay(500);
        }
        await backgroundTask;
        Console.WriteLine("Async/Await Demo Done.");

        // === Async/Await with Cancellation ===
        Console.WriteLine("\nStarting Cancellation Demo...");
        using var cts = new CancellationTokenSource();
        Console.WriteLine("Press 'c' to cancel the operation...\n");

        _ = Task.Run(() =>
        {
            if (Console.ReadKey(true).KeyChar == 'c')
            {
                cts.Cancel();
                Console.WriteLine("\nCancellation requested!");
            }
        });

        try
        {
            await DownloadDataAsync(cts.Token);
            Console.WriteLine("Download completed successfully.");
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Download was canceled.");
        }
    }

    static async Task DoBackgroundWorkAsync()
    {
        Console.WriteLine("Background task started...");
        await Task.Delay(1000);
        Console.WriteLine("Background task finished!");
    }

    static async Task DownloadDataAsync(CancellationToken token)
    {
        Console.WriteLine("Starting download...");
        for (int i = 1; i <= 3; i++)
        {
            await Task.Delay(1000, token);
            Console.WriteLine($"Downloaded chunk {i}/3");
        }
    }
}