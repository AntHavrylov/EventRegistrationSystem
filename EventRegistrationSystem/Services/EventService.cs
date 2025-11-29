using EventRegistrationSystem.Models;
using EventRegistrationSystem.DataAccess.Interfaces;
using EventRegistrationSystem.Services.Interfaces;

namespace EventRegistrationSystem.Services
{
    public class EventService : IEventService
    {
        private readonly IEventsRepository _eventRepository;

        public EventService(IEventsRepository eventRepository) => 
           _eventRepository = eventRepository;

        public async Task<IEnumerable<Event>> GetAllEventsAsync(CancellationToken ct) => 
            await _eventRepository.GetAllEventsAsync(ct);

        public async Task<Event?> GetEventByIdAsync(string eventId, CancellationToken ct) =>
            await _eventRepository.GetEventByIdAsync(eventId, ct);

        public async Task<bool> CreateEventAsync(Event eventItem, CancellationToken ct) =>
            await _eventRepository.CreateEventAsync(eventItem, ct);

        public async Task<IEnumerable<Registration>> GetRegistrationsByEventIdAsync(string eventId, CancellationToken ct) => 
            await _eventRepository.GetRegistrationsByEventIdAsync(eventId, ct);

        public async Task<bool> RegisterForEventAsync(Registration registration, CancellationToken ct) => 
            await _eventRepository.RegisterForEventAsync(registration, ct);
    }
}
