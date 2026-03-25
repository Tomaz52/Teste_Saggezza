using AuthService.Application.Interfaces;
using AuthService.Domain.Entities;

namespace AuthService.Infrastructure.Repositories
{
    // Simple in-memory implementation used for development and tests
    public class InMemoryUserRepository : IUserRepository
    {
        private readonly List<User> _users = new();

        public InMemoryUserRepository()
        {
            // Seed with a demo user (username: demo, password: pass)
            _users.Add(new User { Username = "demo", Password = "pass", Role = "Admin" });
        }

        public Task Add(User user)
        {
            _users.Add(user);
            return Task.CompletedTask;
        }

        public Task<User?> GetById(Guid id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            return Task.FromResult(user);
        }

        public Task<User?> GetByUsername(string username)
        {
            var user = _users.FirstOrDefault(u => u.Username == username);
            return Task.FromResult(user);
        }
    }
}
