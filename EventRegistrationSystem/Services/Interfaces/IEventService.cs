using EventRegistrationSystem.Models;

namespace EventRegistrationSystem.Services.Interfaces;

public interface IEventService
{
    Task<IEnumerable<Event>> GetAllEventsAsync(CancellationToken ct);
    Task<Event?> GetEventByIdAsync(string eventId, CancellationToken ct);
    Task<bool> CreateEventAsync(Event eventItem, CancellationToken ct);
}
