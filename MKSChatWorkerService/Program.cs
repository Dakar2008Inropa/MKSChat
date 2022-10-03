using App.WindowsService;
using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.Logging.EventLog;

internal class Program
{
  private static async Task Main(string[] args)
  {
    using IHost host = Host.CreateDefaultBuilder(args)
    .UseWindowsService(options =>
    {
      options.ServiceName = "MKS Chat Service";
    })
    .ConfigureServices(services =>
    {
      LoggerProviderOptions.RegisterProviderOptions<
          EventLogSettings, EventLogLoggerProvider>(services);

      services.AddSingleton<JokeService>();
      services.AddSingleton<ChatService>();
      services.AddHostedService<WindowsBackgroundService>();
    })
    .ConfigureLogging((context, logging) =>
    {
      // See: https://github.com/dotnet/runtime/issues/47303
      var logginConfiguration = context.Configuration.GetSection("Logging");
      logging.AddConfiguration(logginConfiguration);
    })
    .Build();

    await host.RunAsync();
  }
}