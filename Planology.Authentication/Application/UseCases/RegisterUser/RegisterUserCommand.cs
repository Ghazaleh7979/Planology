namespace Application.UseCases.RegisterUser
{
    public class RegisterUserCommand
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public object FullName { get; set; }
    }
}
