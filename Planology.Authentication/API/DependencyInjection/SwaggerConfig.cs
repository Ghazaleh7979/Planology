using Application.DTOs;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;

namespace API.DependencyInjection
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddSwaggerWithJwt(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Planology",
                    Version = "v1",
                    Description = "Authentication and UserMnagement"
                });

                c.EnableAnnotations();

                c.MapType<LoginDto>(() => new OpenApiSchema
                {
                    Type = "object",
                    Properties =
                    {
                        ["email"] = new OpenApiSchema { Type = "string", Example = new OpenApiString("ghazalehhh137999@gmail.com.com") },
                        ["password"] = new OpenApiSchema { Type = "string", Example = new OpenApiString("Ghaza@7979") }
                    }
                });
                var securitySchema = new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Description = "Enter JWT Bearer token **_only_**",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };

                c.AddSecurityDefinition("Bearer", securitySchema);

                var securityRequirement = new OpenApiSecurityRequirement
                {
                    { securitySchema, new[] { "Bearer" } }
                };

                c.AddSecurityRequirement(securityRequirement);
            });
            return services;
        }
    }
}
