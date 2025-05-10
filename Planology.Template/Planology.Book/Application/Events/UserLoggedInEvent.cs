namespace Application.Events
{
    public record UserLoggedInEvent(string UserId, string Email, DateTime LoggedInAt);
}
