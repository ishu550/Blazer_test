using System;
using System.Threading.Tasks;
using Blazer_test.Models;

namespace Blazer_test.Services
{
    // Simple scoped session service for demo purposes.
    public class UserSessionService
    {
        private UserModel? _currentUser;

        public event Action? OnChange;

        public UserModel? CurrentUser => _currentUser;

        public bool IsAuthenticated => _currentUser != null;

        public Task SignInAsync(UserModel user)
        {
            _currentUser = user;
            OnChange?.Invoke();
            return Task.CompletedTask;
        }

        public Task SignOutAsync()
        {
            _currentUser = null;
            OnChange?.Invoke();
            return Task.CompletedTask;
        }
    }
}