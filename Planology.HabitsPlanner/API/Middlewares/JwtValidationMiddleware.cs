using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Middlewares
{
    public class JwtValidationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _secret;

        public JwtValidationMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _secret = configuration["JwtSettings:SecretKey"];
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Headers.Authorization.FirstOrDefault()?.Split(" ").Last();

            if (string.IsNullOrWhiteSpace(token))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Token not provided");
                return;
            }

            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(_secret);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var identity = new ClaimsIdentity(jwtToken.Claims, "jwt");
                context.User = new ClaimsPrincipal(identity);
            }
            catch
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Invalid token");
                return;
            }

            await _next(context);
        }
    }


}
