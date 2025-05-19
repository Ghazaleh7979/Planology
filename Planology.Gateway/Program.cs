using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Planology.Gateway.Middleware;
using Serilog;
using Serilog.Sinks.MSSqlServer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOcelot(builder.Configuration);
builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
var logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.MSSqlServer(
        connectionString: "Server=localhost;Database=PlanologyLog;Trusted_Connection=True;TrustServerCertificate=True;",
        sinkOptions: new MSSqlServerSinkOptions
        {
            TableName = "LogEvents",
            AutoCreateSqlTable = true
        })
    .CreateLogger();
builder.Host.UseSerilog(logger);

var app = builder.Build();
app.UseMiddleware<RequestLoggingMiddleware>();
await app.UseOcelot();

app.Run();
