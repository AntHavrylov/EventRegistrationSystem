using EventRegistrationSystem.Models;

namespace EventRegistrationSystem.DataAccess.Interfaces
{
    public interface IUsersRepository
    {
        Task<User?> GetUserByEmailAsync(string email, CancellationToken ct);
        Task<bool> CreateUserAsync(User newUser, CancellationToken ct);
    }
}
