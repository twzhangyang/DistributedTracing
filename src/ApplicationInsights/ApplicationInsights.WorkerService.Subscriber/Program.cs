using OpenTelemetry;
using OpenTelemetry.Trace;
using ApplicationInsights.Utils.Messaging;

namespace ApplicationInsights.WorkerService.Subscriber;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureServices((hostContext, services) =>
            {
                services.AddHostedService<Worker>();

                services.AddSingleton<MessageReceiver>();

                services.AddApplicationInsightsTelemetryWorkerService();
            });
}
