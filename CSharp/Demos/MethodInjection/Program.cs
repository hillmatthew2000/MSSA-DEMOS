namespace MethodInjection;

class Program
{
    static void Main()
    {
        var ReportService = new ReportService();
        ILogger logger = new Logger();
        ReportService.GenerateReport("Sales data Q1", logger);
        ReportService.GenerateReport("Sales data Q2", logger);
    }
}

public class ReportService
{
    public void GenerateReport(string data, ILogger logger)
    {
        if (logger is null)
            throw new ArgumentNullException(nameof(logger));
            
        logger.Log("Report generation started");
        logger.Log($"Generating report with data: {data}");
        logger.Log("Report generation completed");
    }
}

public interface ILogger
{
    void Log(string message);
}
public class Logger : ILogger
{
    public void Log(string message)
    {
        Console.WriteLine($"Log: {message}");
    }
}