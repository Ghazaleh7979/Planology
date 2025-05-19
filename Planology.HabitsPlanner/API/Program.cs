using API.DependencyInjection;
using API.Middlewares;
using FluentValidation.AspNetCore;
using Infrastructure.SignalR;

var builder = WebApplication.CreateBuilder(args);




builder.Services.AddControllers();
builder.Services.AddRepositories();
builder.Services.AddUseCases();
builder.Services.AddServices();
builder.Services.AddOpenApi();
builder.Services.AddJwtValidation(builder.Configuration);
builder.Services.AddSwaggerWithJwt();
builder.Services.AddMassTransitWithRabbitMq();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddMongoDB(builder.Configuration);
builder.Services.AddSignalR();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    var url = "http://localhost:7010/swagger/index.html";
    try
    {
        System.Diagnostics.Process.Start("chrome", url);
    }
    catch
    {
        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
        {
            FileName = url,
            UseShellExecute = true
        });
    }
}
app.UseMiddleware<JwtValidationMiddleware>();

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapHub<NotificationHub>("/notificationhub");
app.MapControllers();
app.Run();
