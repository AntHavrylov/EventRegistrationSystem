using Dapper;
using EventRegistrationSystem.DataAccess.Interfaces;
using EventRegistrationSystem.Models;

namespace EventRegistrationSystem.DataAccess;

public class UsersRepository : IUsersRepository
{
    private const string _usersTable = "Users";

    private readonly IDbConnectionFactory _dbConnectionFactory;

    public UsersRepository(IDbConnectionFactory dbConnectionFactory) =>
        _dbConnectionFactory = dbConnectionFactory;

    public async Task<User?> GetUserByEmailAsync(string email, CancellationToken ct)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync(ct);
        var result = await connection.QuerySingleOrDefaultAsync<User>(
            new CommandDefinition($"""
            SELECT * FROM {_usersTable}
            WHERE Email = @Email
            """, 
            new { Email = email }, 
            cancellationToken: ct));
        return result;
    }

    public async Task<bool> CreateUserAsync(User newUser, CancellationToken ct)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync(ct);
        var result = await connection.ExecuteAsync(
            new CommandDefinition($"""
            INSERT INTO {_usersTable} (Id, Name, Email, PasswordHash, Salt)
            VALUES (@Id, @Name, @Email, @PasswordHash, @Salt);
            """,
            newUser,
            cancellationToken: ct));
        return result > 0;
    }

}
