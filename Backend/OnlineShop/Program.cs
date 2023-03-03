using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using OnlineShop.AutoMapper;
using OnlineShop.Data;
using OnlineShop.Data.Repository;
using OnlineShop.Data.Repository.Interface;
using OnlineShop.Middleware;
using OnlineShop.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    var jwtSecurityScheme = new OpenApiSecurityScheme
    {
        BearerFormat = "JWT",
        Name = "JWT Authentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    c.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {jwtSecurityScheme, Array.Empty<string>()}
    });
});

builder.Services.AddDbContext<OnlineShopeDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SQLDB")));


builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddScoped<MainServices>();
builder.Services.AddScoped<AthenticationServices>();
builder.Services.AddScoped<UserServices>();

builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

builder.Services.AddAutoMapper(typeof(MappingProfile));

////serilog
//builder.Host.UseSerilog((webHostBuilderContext, loggerConfiguration) =>
//{
//    loggerConfiguration.MinimumLevel.Debug();
//    loggerConfiguration.Enrich.FromLogContext();
//    loggerConfiguration.Enrich.WithProperty("ApplicationName", Assembly.GetExecutingAssembly().GetName().Name);
//    loggerConfiguration.Enrich.WithProperty("EnvironmentName",
//        webHostBuilderContext.HostingEnvironment.EnvironmentName);

//    loggerConfiguration.MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
//        .MinimumLevel.Override("System", LogEventLevel.Warning)
//        .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
//        .MinimumLevel.Override("Microsoft.EntityFrameworkCore.Model.Validation", LogEventLevel.Error)
//        .MinimumLevel.Override("Microsoft.Hosting.Lifetime", LogEventLevel.Warning)
//        .MinimumLevel.Override("System.Net.Http.HttpClient", LogEventLevel.Warning)
//        .MinimumLevel.Override("Microsoft.EntityFrameworkCore.Database.Command", LogEventLevel.Error)
//        .MinimumLevel.Override("Microsoft.EntityFrameworkCore.Query", LogEventLevel.Error);


//    loggerConfiguration.WriteTo.Async(loggerSinkConfiguration =>
//    {
//        loggerSinkConfiguration.Console(LogEventLevel.Debug,
//            theme: AnsiConsoleTheme.Code,
//            outputTemplate:
//            "[{Timestamp:HH:mm:ss} {Level:u3} <{SourceContext}>] {Message:lj} {Properties:j}{NewLine}{Exception}");

//        if (!builder.Environment.IsDevelopment())
//        {
//            var elasticSearchUserName = webHostBuilderContext.Configuration["ElasticSearchOptions:UserName"];
//            var elasticSearchPassword = webHostBuilderContext.Configuration["ElasticSearchOptions:Password"];
//            var elasticSearchHost = webHostBuilderContext.Configuration["ElasticSearchOptions:Host"];

//            loggerSinkConfiguration.Elasticsearch(new ElasticsearchSinkOptions(new Uri(elasticSearchHost))
//            {
//                ModifyConnectionSettings = connectionConfiguration =>
//                    connectionConfiguration.BasicAuthentication(elasticSearchUserName, elasticSearchPassword),
//                AutoRegisterTemplate = false,
//                ConnectionTimeout = TimeSpan.FromSeconds(30),
//                InlineFields = true,
//                MinimumLogEventLevel = LogEventLevel.Information,
//                IndexDecider = (logEvent, dateTimeOffset) =>
//                    $"online-shop-{dateTimeOffset:yyyy-MM-dd}-{logEvent.Level.ToString().ToLowerInvariant()}",
//                EmitEventFailure = EmitEventFailureHandling.WriteToSelfLog |
//                                   EmitEventFailureHandling.RaiseCallback,
//                FailureCallback = logEvent => Console.WriteLine(logEvent.Exception!.ToString())
//            });
//        }
//    });
//});

//jwt token 
builder.Services.AddAuthentication(option =>
    {
        option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        option.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(o =>
    {
        o.TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey
                (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = false,
            ValidateIssuerSigningKey = true
        };
    });
builder.Services.AddAuthorization();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseCustomExceptionHandler();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();