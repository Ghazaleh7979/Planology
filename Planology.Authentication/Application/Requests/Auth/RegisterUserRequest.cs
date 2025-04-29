namespace Application.Requests.Login
{
    public class RegisterUserRequest
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public object FullName { get; set; }
    }
}
