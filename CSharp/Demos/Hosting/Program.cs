using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Hosting;
class Program
{
    static async Task Main(string[] args)
    {
        // Configure a builder using Microsoft.Extensions.Hosting
        var builder = Host.CreateApplicationBuilder(args);

        // Ensures no other logging will take place
        builder.Logging.ClearProviders(); 
        // Adds this logging console
        builder.Logging.AddConsole(); 

        // Register the background service
        builder.Services.AddHostedService<ConsoleWorker>();

        // Creating a host
        var host = builder.Build();

        // Run the host (starts background services)
        await host.RunAsync();
    }

    // Background service that logs messages to the console
    public class ConsoleWorker : BackgroundService
    {
        private readonly ILogger<ConsoleWorker> _logger;

        // Inject logger via constructor
        public ConsoleWorker(ILogger<ConsoleWorker> logger)
        {
            _logger = logger;
        }

        // Main execution loop for the background service
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("App starting in...");
            for (int i = 0; i < 5 && !stoppingToken.IsCancellationRequested; i++)
            {
                _logger.LogInformation($"Working... {i + 1}");
                await Task.Delay(500);
            }
            _logger.LogInformation("App is shutting down...");
        }
    }
}