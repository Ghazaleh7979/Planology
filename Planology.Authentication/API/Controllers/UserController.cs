using Application.DTOs;
using Application.UseCases.User;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(
        GetUserByIdUseCase getUserById,
        CreateUserUseCase createUser,
        UpdateUserUseCase updateUser,
        DeleteUserUseCase deleteUser) : ControllerBase
    {
        private readonly GetUserByIdUseCase _getUserById = getUserById;
        private readonly CreateUserUseCase _createUser = createUser;
        private readonly UpdateUserUseCase _updateUser = updateUser;
        private readonly DeleteUserUseCase _deleteUser = deleteUser;

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var user = await _getUserById.ExecuteAsync(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserDto userDto)
        {
            var createdUser = await _createUser.ExecuteAsync(userDto);
            return CreatedAtAction(nameof(GetUserById), new { id = createdUser.UserId }, createdUser);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UserDto userDto)
        {
            var result = await _updateUser.ExecuteAsync(id, userDto);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            var result = await _deleteUser.ExecuteAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}