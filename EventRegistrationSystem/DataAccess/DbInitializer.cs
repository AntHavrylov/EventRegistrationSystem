using Dapper;

namespace EventRegistrationSystem.DataAccess;


public class DbInitializer
{
    private readonly IDbConnectionFactory _dbConnectionFactory;

    public DbInitializer(IDbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    public async Task InitializeAsync(CancellationToken ct = default)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync(ct);

        await connection.ExecuteAsync("""
            CREATE TABLE IF NOT EXISTS Users (
            Id TEXT PRIMARY KEY,
            Name NVARCHAR(200) NOT NULL,
            Email NVARCHAR(200) NOT NULL,
            PasswordHash NVARCHAR(500) NOT NULL,
            Salt NVARCHAR(200) NOT NULL);
            """);

        await connection.ExecuteAsync("""
            CREATE TABLE IF NOT EXISTS Events (
            Id TEXT PRIMARY KEY,
            CreatorId TEXT NOT NULL,
            Name NVARCHAR(200) NOT NULL,
            Description NVARCHAR(2000) NOT NULL,
            Location NVARCHAR(500) NOT NULL,
            StartDate DATETIME2 NOT NULL,
            EndDate DATETIME2 NOT NULL,
            CreatedAt DATETIME2 NOT NULL,
            FOREIGN KEY (CreatorId) REFERENCES Users(Id));
            """);

        await connection.ExecuteAsync("""
            CREATE TABLE IF NOT EXISTS Registrations (
            Id TEXT PRIMARY KEY,
            EventId TEXT NOT NULL,
            Name NVARCHAR(200) NOT NULL,
            Email NVARCHAR(200) NOT NULL,
            PhoneNumber NVARCHAR(50),
            RegisteredAt DATETIME2 NOT NULL,
            FOREIGN KEY (EventId) REFERENCES Events(Id));
            """);
    }

}
