namespace Application.Events
{
    public class UserLoggedOutEvent
    {
        public string UserId { get; set; } = null!;
        public bool IsLoggedIn { get; set; }
    }
}
