using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.Logging.EventLog;

namespace ChatClient
{
  internal static class Program
  {
    [STAThread]
    private static void Main(string[] args)
    {
      ApplicationConfiguration.Initialize();

      using IHost host = Host.CreateDefaultBuilder(args)
        .ConfigureServices(services =>
        {
          LoggerProviderOptions.RegisterProviderOptions<
              EventLogSettings, EventLogLoggerProvider>(services);
          services.AddTransient<MainForm>();
        })
        .ConfigureLogging((context, logging) =>
        {
          // See: https://github.com/dotnet/runtime/issues/47303
          logging.AddConfiguration(
              context.Configuration.GetSection("Logging"));
        })
        .Build();

      var mainForm = host.Services.GetRequiredService<MainForm>();
      Application.Run(mainForm);
    }
  }
}