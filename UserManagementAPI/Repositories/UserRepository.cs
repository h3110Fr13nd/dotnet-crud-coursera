using UserManagementAPI.Models;

namespace UserManagementAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users = new();
        private int _nextId = 1;

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await Task.FromResult(_users);
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await Task.FromResult(_users.FirstOrDefault(u => u.Id == id));
        }

        public async Task<User> CreateUserAsync(User user)
        {
            user.Id = _nextId++;
            user.CreatedAt = DateTime.UtcNow;
            _users.Add(user);
            return await Task.FromResult(user);
        }

        public async Task<User?> UpdateUserAsync(int id, User user)
        {
            var existingUser = _users.FirstOrDefault(u => u.Id == id);
            if (existingUser == null) return null;

            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            existingUser.Password = user.Password;

            return await Task.FromResult(existingUser);
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null) return false;

            _users.Remove(user);
            return await Task.FromResult(true);
        }
    }
}