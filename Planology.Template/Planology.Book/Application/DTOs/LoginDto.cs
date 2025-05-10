using Swashbuckle.AspNetCore.Annotations;

namespace Application.DTOs
{
    public class LoginDto
    {
        [SwaggerSchema("ghazalehhh137999@gmail.com")]
        public string Email { get; set; }

        [SwaggerSchema("Ghaza@7979")]
        public string Password { get; set; }
    }
}
