using StackExchange.Redis;
using System.Security.Claims;
using System.Text.Json;

namespace Planology.PlannerSelectorService.Features.GetAvailablePlanners
{
    public static class GetAvailablePlannersEndpoint
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/planners", async (
                HttpContext context,
                IConnectionMultiplexer redis) =>
            {
                var userId = context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrWhiteSpace(userId))
                    return Results.Unauthorized();

                var db = redis.GetDatabase();
                var key = $"user:{userId}:allowed_planners";

                var plannersJson = await db.StringGetAsync(key);
                if (string.IsNullOrWhiteSpace(plannersJson))
                    return Results.Ok(new AvailablePlannersResult());

                var planners = JsonSerializer.Deserialize<List<string>>(plannersJson!) ?? new();

                return Results.Ok(new AvailablePlannersResult { Planners = planners });
            });
        }
    }
}
