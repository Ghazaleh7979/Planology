using StackExchange.Redis;
using System.Text.Json;

namespace Planology.PlannerSelectorService.Features.SelectPlanner
{
    public class PlannerValidator
    {
        private readonly IDatabase _db;

        public PlannerValidator(IConnectionMultiplexer redis)
        {
            _db = redis.GetDatabase();
        }
        public async Task<bool> IsPlannerTypeValidAsync(string plannerType)
        {
            var plannersJson = await _db.StringGetAsync("planner:types");
            if (string.IsNullOrWhiteSpace(plannersJson)) return false;

            var planners = JsonSerializer.Deserialize<List<string>>(plannersJson!) ?? new();
            return planners.Contains(plannerType.ToLowerInvariant());
        }

        public async Task<bool> IsUserAllowedAsync(string userId, string plannerType)
        {
            var key = $"user:{userId}:allowed_planners";
            var allowedJson = await _db.StringGetAsync(key);
            if (string.IsNullOrWhiteSpace(allowedJson)) return false;

            var allowed = JsonSerializer.Deserialize<List<string>>(allowedJson!) ?? new();
            return allowed.Contains(plannerType.ToLowerInvariant());
        }
    }
}
