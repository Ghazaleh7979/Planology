using StackExchange.Redis;
using System.Security.Claims;

namespace Planology.PlannerSelectorService.Features.GetAvailablePlanners
{
    public static class GetCurrentPlannerEndpoint
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/planner/current", async (
                HttpContext context,
                IConnectionMultiplexer redis) =>
            {
                var userId = context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                if (string.IsNullOrWhiteSpace(userId))
                    return Results.Unauthorized();

                var db = redis.GetDatabase();
                var key = $"user:{userId}:selected_planner";
                var plannerType = await db.StringGetAsync(key);
                if (string.IsNullOrWhiteSpace(plannerType.ToString()))
                    return Results.NotFound("No planner selected");

                var redirectKey = $"planner:redirect:{plannerType.ToString().ToLowerInvariant()}";
                var redirectUrl = await db.StringGetAsync(redirectKey);
                if (string.IsNullOrWhiteSpace(redirectUrl))
                    return Results.NotFound("Redirect URL not found for planner");

                return Results.Redirect(redirectUrl!);
            });
        }
    }
}
