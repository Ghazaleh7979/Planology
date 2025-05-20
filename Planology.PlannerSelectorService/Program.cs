using Planology.PlannerSelectorService.Features.GetAvailablePlanners;
using Planology.PlannerSelectorService.Features.SelectPlanner;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSingleton<IConnectionMultiplexer>(
    ConnectionMultiplexer.Connect(builder.Configuration.GetConnectionString("Redis") ?? "localhost"));

var app = builder.Build();

SelectPlannerEndpoint.Map(app);
GetAvailablePlannersEndpoint.Map(app);
GetCurrentPlannerEndpoint.Map(app);

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
