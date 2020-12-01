using System;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Mgi.Apl.Web
{
    public class Program
    {

        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                          .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                          .ConfigureWebHostDefaults(webBuilder =>
                          {
                              webBuilder.UseStartup<Startup>();
                          }).UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration
                              .MinimumLevel.Override("Microsoft.AspNetCore", Serilog.Events.LogEventLevel.Warning)
                              .ReadFrom.Configuration(hostingContext.Configuration)
                              .Enrich.FromLogContext()
                              //.WriteTo.Debug()
                              //.WriteTo.ColoredConsole(Serilog.Events.LogEventLevel.Verbose)
                              .WriteTo.Console(
                                  outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u4}] {Message}{NewLine}{Exception}",
                                  restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Debug)
                              .WriteTo.File("Logs\\MGI.log",
                              fileSizeLimitBytes: 16 * 1024 * 1024,
                              buffered: true,
                              rollingInterval: RollingInterval.Day,
                              rollOnFileSizeLimit: true,
                              restrictedToMinimumLevel: Serilog.Events.LogEventLevel.Debug,
                              flushToDiskInterval: TimeSpan.FromSeconds(10)));
        }

    }
}
