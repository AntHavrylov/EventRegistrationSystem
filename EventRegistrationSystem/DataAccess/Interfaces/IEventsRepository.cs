using EventRegistrationSystem.Models;

namespace EventRegistrationSystem.DataAccess.Interfaces;

public interface IEventsRepository
{
    Task<IEnumerable<Event>> GetAllEventsAsync(CancellationToken ct);
    Task<Event?> GetEventByIdAsync(string eventId, CancellationToken ct);
    Task<bool> CreateEventAsync(Event eventItem, CancellationToken ct);
}
