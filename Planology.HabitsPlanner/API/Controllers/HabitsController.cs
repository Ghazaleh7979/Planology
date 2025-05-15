using Application.Helper;
using Application.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HabitsController : ControllerBase
    {
        private readonly HabitService _habitService;

        public HabitsController(HabitService habitService)
        {
            _habitService = habitService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateHabitRequest request)
        {
            await _habitService.CreateAsync(request);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateHabitRequest request)
        {
            await _habitService.UpdateAsync(request);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _habitService.DeleteAsync(id);
            return Ok();
        }

        [HttpPost("log")]
        public async Task<IActionResult> Log([FromBody] LogHabitRequest request)
        {
            await _habitService.LogAsync(request);
            return Ok();
        }

        [HttpPost("check")]
        public async Task<IActionResult> Check([FromBody] CheckHabitRequest request)
        {
            await _habitService.CheckAsync(request.HabitId);
            return Ok();
        }

        [HttpGet("today")]
        public async Task<IActionResult> GetTodayHabits()
        {
            var habits = await _habitService.GetTodayHabitsAsync();
            return Ok(habits);
        }

        [HttpGet("user")]
        public async Task<IActionResult> GetUserHabits()
        {
            var habits = await _habitService.GetUserHabitsAsync();
            return Ok(habits);
        }
    }
}
