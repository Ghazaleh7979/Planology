using Application.Extensions;
using Application.Helper;
using Application.Interfaces;
using Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Habits
{
    public class DeleteHabitUseCase
    {
        private readonly IHabitRepository _habitRepo;
        private readonly ICurrentUserService _currentUser;
        private readonly UserSessionStore _sessionStore;

        public DeleteHabitUseCase(
            IHabitRepository habitRepo,
            ICurrentUserService currentUser,
            UserSessionStore sessionStore)
        {
            _habitRepo = habitRepo;
            _currentUser = currentUser;
            _sessionStore = sessionStore;
        }

        public async Task ExecuteAsync(string habitId)
        {
            _currentUser.CheckUserLoggedIn(_sessionStore);

            var habit = await _habitRepo.GetByIdAsync(habitId);
            if (habit == null)
                throw new KeyNotFoundException("Habit not found.");

            await _habitRepo.DeleteAsync(habitId);
        }
    }

}
