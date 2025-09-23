namespace DependencyInjection
{
    class Program
    {
        static void Main()
        {
            ILogger logger = new Logger();
            var reportService = new ReportService(logger);
            reportService.GenerateReport("Sales data Q1");
            reportService.GenerateReport("Sales data Q2");
        }
    }

    public class ReportService
    {
        private readonly ILogger _logger;

        public ReportService(ILogger logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void GenerateReport(string data)
        {
            _logger.Log("Report generation started");
            _logger.Log($"Generating report with data: {data}");
            _logger.Log("Report generation completed");
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
}