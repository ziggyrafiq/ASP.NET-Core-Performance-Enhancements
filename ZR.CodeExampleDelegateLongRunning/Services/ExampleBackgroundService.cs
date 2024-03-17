using Microsoft.Extensions.Hosting;

namespace ZR.CodeExampleDelegateLongRunning.Services
{
    public class ExampleBackgroundService: BackgroundService
    {
        private readonly ILogger<ExampleBackgroundService> logger;

        public ExampleBackgroundService(ILogger<ExampleBackgroundService> logger)
        {
            this.logger = logger;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                // Replace this with your actual long-running task logic
                this.logger.LogInformation("Background service is running at: {time}", DateTimeOffset.Now);

                // Simulate a task that runs every 10 minutes
                await Task.Delay(TimeSpan.FromMinutes(10), stoppingToken);
            }
        }
    }
}
