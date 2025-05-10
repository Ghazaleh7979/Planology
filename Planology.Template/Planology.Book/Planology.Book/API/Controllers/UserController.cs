using Application.DTOs;
using Application.UseCases.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class UserController(
        GetUserByIdUseCase getUserById,
        GetAllUserUseCase getAllUser,
        UpdateUserUseCase updateUser,
        DeleteUserUseCase deleteUser) : ControllerBase
    {
        private readonly GetUserByIdUseCase _getUserById = getUserById;
        private readonly GetAllUserUseCase _getAllUser = getAllUser;
        private readonly UpdateUserUseCase _updateUser = updateUser;
        private readonly DeleteUserUseCase _deleteUser = deleteUser;

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var user = await _getUserById.ExecuteAsync(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUser()
        {
            var allUser = await _getAllUser.ExecuteAsync();
            return Ok(allUser);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, [FromBody] UserDto userDto)
        {
            var result = await _updateUser.ExecuteAsync(id, userDto);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var result = await _deleteUser.ExecuteAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}