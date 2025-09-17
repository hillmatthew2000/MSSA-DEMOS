namespace AsyncQuizApp;

class Program
{
    public static async Task Main(string[] args)
    {
        using var cts = new CancellationTokenSource();
       
        try
        {
            await AskQuestionAsync("What is 2 + 2?", cts);
            await AskQuestionAsync("Name a color?", cts);
            await AskQuestionAsync("What is the capital of France?", cts);
 
            Console.WriteLine("\nQuiz is finished");
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("\nQuiz cancelled");
        }
 
    }
 
    static async Task AskQuestionAsync(string question, CancellationTokenSource cts)
    {
        if (cts.IsCancellationRequested)
            throw new OperationCanceledException();
 
        Console.WriteLine($"{question} (type 'c' and press Enter to cancel)");
        var inputTask = Task.Run(() => Console.ReadLine());
        var delayTask = Task.Delay(5000);
 
        var finished = await Task.WhenAny(inputTask, delayTask);
        if (finished == inputTask)
        {
            string answer = await inputTask;
 
            if (answer.Trim().ToLower() == "c")
            {
                cts.Cancel();
                throw new OperationCanceledException();
            }
            Console.WriteLine($"You answered: {answer}");
        }
        else
        {
            Console.WriteLine("Time is up");
        }
    }
}
 
 