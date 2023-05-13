using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;
using System.Reflection;

public static class SerilogExtention
{
    public static void UseSerilog(this WebApplicationBuilder builder)
    {
        var outputTemplate = "[{Timestamp:HH:mm:ss}],[{Level:u3}],[{RequestId}],[<{SourceContext}>],[{Message:lj}],[{Exception}]{NewLine}";

        builder.Logging.ClearProviders();
        builder.Host.UseSerilog((webHostBuilderContext, loggerConfiguration) =>
        {
            loggerConfiguration.MinimumLevel.Debug();
            loggerConfiguration.Enrich.FromLogContext();
            loggerConfiguration.Enrich.WithProperty("ApplicationName", Assembly.GetExecutingAssembly().GetName().Name);
            loggerConfiguration.Enrich.WithProperty("EnvironmentName", webHostBuilderContext.HostingEnvironment.EnvironmentName);

            loggerConfiguration.MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
                               .MinimumLevel.Override("System", LogEventLevel.Warning)
                               .MinimumLevel.Override("Microsoft", LogEventLevel.Warning);

            loggerConfiguration.WriteTo.Async(loggerSinkConfiguration =>
            {
                loggerSinkConfiguration.Console(
                    restrictedToMinimumLevel: LogEventLevel.Debug,
                    theme: AnsiConsoleTheme.Code,
                    outputTemplate: outputTemplate);

                loggerSinkConfiguration.File(
                    path: "C:\\repos\\Online_Shop_Website\\Logs\\All_.log",
                    restrictedToMinimumLevel: LogEventLevel.Information, 
                    rollingInterval : RollingInterval.Day , 
                    outputTemplate: outputTemplate);

                loggerSinkConfiguration.File(
                   path: "C:\\repos\\Online_Shop_Website\\Logs\\Error_.log",
                   restrictedToMinimumLevel: LogEventLevel.Error,
                   rollingInterval: RollingInterval.Day,
                   outputTemplate: outputTemplate);
            });
        });

    }
}