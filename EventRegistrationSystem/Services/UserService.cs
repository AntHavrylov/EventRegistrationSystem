using EventRegistrationSystem.DataAccess.Interfaces;
using EventRegistrationSystem.Models;
using EventRegistrationSystem.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EventRegistrationSystem.Services;

public class UserService : IUserService
{
    private readonly IUsersRepository _usersRepository;
    private readonly IEncryptionService _encryptionService;

    public UserService(IUsersRepository usersRepository,
        IEncryptionService encryptionService)
    { 
        _usersRepository = usersRepository;
        _encryptionService = encryptionService;
    }


    public async Task<bool> CreateUserAsync(User newUser, CancellationToken ct) =>
        await _usersRepository.CreateUserAsync(newUser, ct);

    public async Task<string?> LoginAsync(string email, string password, CancellationToken ct) 
    {
        var user = await _usersRepository.GetUserByEmailAsync(email, ct) 
            ?? throw new ArgumentNullException("User not found.");

        var isValidPassword = _encryptionService
            .VerifyPassword(password, user.PasswordHash, user.Salt);

        return isValidPassword
            ? GenerateToken(user.Id)
            : null;
    }

    private string GenerateToken(string userId)
    {
        var claims = new[] { 
            new Claim(ClaimTypes.NameIdentifier, userId)     
        };
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("my-super-secret-key-minimum-32-characters-long!"));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(claims: claims, expires: DateTime.UtcNow.AddDays(7), signingCredentials: creds);
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

}
