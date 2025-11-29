using EventRegistrationSystem.Models;

namespace EventRegistrationSystem.Services.Interfaces;

public interface IEventService
{
    Task<IEnumerable<Event>> GetAllEventsAsync(CancellationToken ct);
    Task<Event?> GetEventByIdAsync(string eventId, CancellationToken ct);
    Task<bool> CreateEventAsync(Event eventItem, CancellationToken ct);
    Task<IEnumerable<Registration>> GetRegistrationsByEventIdAsync(string eventId, CancellationToken ct);
    Task<bool> RegisterForEventAsync(Registration registration, CancellationToken ct);
}
