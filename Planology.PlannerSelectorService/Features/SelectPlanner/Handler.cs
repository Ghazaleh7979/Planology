using Planology.PlannerSelectorService.Features.SelectPlanner.Events;
using StackExchange.Redis;
using System.Security.Claims;

namespace Planology.PlannerSelectorService.Features.SelectPlanner;

public static class SelectPlannerEndpoint
{
    public static void Map(WebApplication app)
    {
        app.MapPost("/planner/select", async (
            SelectPlannerCommand cmd,
            HttpContext context,
            IConnectionMultiplexer redis) =>
        {
            var userId = context.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            // check error
            if (string.IsNullOrWhiteSpace(userId))
                return Results.Unauthorized();
            var validator = new PlannerValidator(redis);
            if (!await validator.IsPlannerTypeValidAsync(cmd.PlannerType))
                return Results.BadRequest("Planner type not found.");
            if (!await validator.IsUserAllowedAsync(userId, cmd.PlannerType))
                return Results.Forbid();

            // connect redis
            var db = redis.GetDatabase();
            await db.StringSetAsync($"user:{userId}:selected_planner", cmd.PlannerType, TimeSpan.FromHours(5));

            // event
            PlannerSelected.Raise(userId, cmd.PlannerType);

            // redirect
            var redirectKey = $"planner:redirect:{cmd.PlannerType.ToLower()}";
            var redirectUrl = await db.StringGetAsync(redirectKey);
            if (string.IsNullOrWhiteSpace(redirectUrl))
                return Results.NotFound("Redirect URL not found");
            return Results.Redirect(redirectUrl!);
        });
    }
}

