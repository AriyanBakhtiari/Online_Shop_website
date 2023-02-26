using Microsoft.EntityFrameworkCore;
using OnlineShop.Data;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Elasticsearch;
using Serilog.Sinks.SystemConsole.Themes;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<OnlineShopeDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SQLDB")));


//serilog
builder.Host.UseSerilog((webHostBuilderContext, loggerConfiguration) =>
{
    loggerConfiguration.MinimumLevel.Debug();
    loggerConfiguration.Enrich.FromLogContext();
    loggerConfiguration.Enrich.WithProperty("ApplicationName", Assembly.GetExecutingAssembly().GetName().Name);
    loggerConfiguration.Enrich.WithProperty("EnvironmentName",
        webHostBuilderContext.HostingEnvironment.EnvironmentName);

    loggerConfiguration.MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
        .MinimumLevel.Override("System", LogEventLevel.Warning)
        .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
        .MinimumLevel.Override("Microsoft.EntityFrameworkCore.Model.Validation", LogEventLevel.Error)
        .MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Warning)
        .MinimumLevel.Override("System.Net.Http.HttpClient", LogEventLevel.Warning)
        .MinimumLevel.Override("Microsoft.EntityFrameworkCore.Database.Command", LogEventLevel.Error)
        .MinimumLevel.Override("Microsoft.EntityFrameworkCore.Query", LogEventLevel.Error);


    loggerConfiguration.WriteTo.Async(loggerSinkConfiguration =>
    {
        loggerSinkConfiguration.Console(LogEventLevel.Debug,
            theme: AnsiConsoleTheme.Code,
            outputTemplate:
            "[{Timestamp:HH:mm:ss} {Level:u3} <{SourceContext}>] {Message:lj} {Properties:j}{NewLine}{Exception}");

        if (!builder.Environment.IsDevelopment())
        {
            var elasticSearchUserName = webHostBuilderContext.Configuration["ElasticSearchOptions:UserName"];
            var elasticSearchPassword = webHostBuilderContext.Configuration["ElasticSearchOptions:Password"];
            var elasticSearchHost = webHostBuilderContext.Configuration["ElasticSearchOptions:Host"];

            loggerSinkConfiguration.Elasticsearch(new ElasticsearchSinkOptions(new Uri(elasticSearchHost))
            {
                ModifyConnectionSettings = connectionConfiguration =>
                    connectionConfiguration.BasicAuthentication(elasticSearchUserName, elasticSearchPassword),
                AutoRegisterTemplate = false,
                ConnectionTimeout = TimeSpan.FromSeconds(30),
                InlineFields = true,
                MinimumLogEventLevel = LogEventLevel.Information,
                IndexDecider = (logEvent, dateTimeOffset) =>
                    $"online-shop-{dateTimeOffset:yyyy-MM-dd}-{logEvent.Level.ToString().ToLowerInvariant()}",
                EmitEventFailure = EmitEventFailureHandling.WriteToSelfLog |
                                   EmitEventFailureHandling.RaiseCallback,
                FailureCallback = logEvent => Console.WriteLine(logEvent.Exception!.ToString())
            });
        }
    });
});


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();