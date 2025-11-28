using EventRegistrationSystem.Models;

namespace EventRegistrationSystem.Services.Interfaces;

public interface IUserService
{
    Task<bool> CreateUserAsync(User user, CancellationToken ct);
    Task<string?> LoginAsync(string email, string password, CancellationToken ct);
}
