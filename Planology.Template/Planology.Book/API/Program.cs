using API.DependencyInjection;
using API.Middlewares;
using Domain.Entities;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);




builder.Services.AddControllers();
builder.Services.AddRepositories();
builder.Services.AddUseCases();
builder.Services.AddScoped<JwtSettings>();
builder.Services.AddIdentityConfig(builder.Configuration);
builder.Services.AddOpenApi();
builder.Services.AddJwtAuthentication(builder.Configuration);
builder.Services.AddSwaggerWithJwt();
builder.Services.AddMassTransitWithRabbitMq();
builder.Services.AddFluentValidationAutoValidation();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    var url = "https://localhost:7009/swagger/index.html";
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
app.UseGlobalExceptionHandler();
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
