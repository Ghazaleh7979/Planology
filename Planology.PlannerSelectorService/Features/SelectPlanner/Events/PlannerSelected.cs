namespace Planology.PlannerSelectorService.Features.SelectPlanner.Events;

public class PlannerSelectedEventArgs : EventArgs
{
    public string UserId { get; }
    public string PlannerType { get; }

    public PlannerSelectedEventArgs(string userId, string plannerType)
    {
        UserId = userId;
        PlannerType = plannerType;
    }
}

public static class PlannerSelected
{
    public static event EventHandler<PlannerSelectedEventArgs>? OnPlannerSelected;

    public static void Raise(string userId, string plannerType)
    {
        OnPlannerSelected?.Invoke(null, new PlannerSelectedEventArgs(userId, plannerType));
    }
}
