using Dapper;
using EventRegistrationSystem.Models;
using EventRegistrationSystem.DataAccess.Interfaces;

namespace EventRegistrationSystem.DataAccess;

public class EventsRepository : IEventsRepository
{
    private const string _eventsTable = "Events";
    private const string _eventRegistrationsTable = "Registrations";

    private readonly IDbConnectionFactory _dbConnectionFactory;

    public EventsRepository(IDbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    public async Task<IEnumerable<Event>> GetAllEventsAsync(CancellationToken ct = default)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync(ct);
        var events = await connection.QueryAsync<Event>(
            new CommandDefinition(
            $"""
            SELECT *
            FROM {_eventsTable};
            """, cancellationToken: ct));
        return events;
    }

    public async Task<Event?> GetEventByIdAsync(string eventId, CancellationToken ct = default)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync(ct);
        var eventItem = await connection.QuerySingleOrDefaultAsync<Event>(
            new CommandDefinition(
            $"""
            SELECT *
            FROM {_eventsTable}
            WHERE Id = @eventId;
            """, new { eventId }, cancellationToken: ct));
        return eventItem;
    }

    public async Task<bool> CreateEventAsync(Event eventItem, CancellationToken ct = default)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync(ct);
        var result = await connection.ExecuteAsync(
            new CommandDefinition(
            $"""
            INSERT INTO {_eventsTable} (Id, CreatorId, Name, Description, Location, StartDate, EndDate, CreatedAt)
            VALUES (@Id, @CreatorId, @Name, @Description, @Location, @StartDate, @EndDate, @CreatedAt);
            """, eventItem, cancellationToken: ct));
        return result > 0;
    }

    public async Task<IEnumerable<Registration>> GetRegistrationsByEventIdAsync(string eventId, CancellationToken ct = default)
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync(ct);
        var registrations = await connection.QueryAsync<Registration>(
            new CommandDefinition(
            $"""
            SELECT *
            FROM {_eventRegistrationsTable}
            WHERE EventId = @eventId;
            """, new { eventId }, cancellationToken: ct));
        return registrations;
    }

    public async Task<bool> RegisterForEventAsync(Registration registration,CancellationToken ct = default) 
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync(ct);
        var result = await connection.ExecuteAsync(
            new CommandDefinition(
            $"""
            INSERT INTO {_eventRegistrationsTable} (Id, EventId, Name, Email, PhoneNumber, RegisteredAt)
            VALUES (@Id, @EventId, @Name, @Email, @PhoneNumber, @RegisteredAt);
            """, registration, cancellationToken: ct));
        return result > 0;
    }
}
