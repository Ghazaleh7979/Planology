using System.Collections.Concurrent;

namespace Application.Helper
{
    public class UserSessionStore
    {
        private readonly ConcurrentDictionary<string, bool> _sessions = new();

        public void SetLoggedIn(string userId, bool loggedIn)
        {
            _sessions[userId] = loggedIn;
        }

        public bool IsLoggedIn(string userId)
        {
            return _sessions.TryGetValue(userId, out var status) && status;
        }
    }

}
