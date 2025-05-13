namespace Application.Events
{
    public class UserLoggedInEvent
    {
        public string UserId { get; set; } = null!;
        public bool IsLoggedIn { get; set; }
    }

}
