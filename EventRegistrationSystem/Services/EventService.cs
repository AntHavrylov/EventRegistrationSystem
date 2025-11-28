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

        public Task<IEnumerable<Event>> GetAllEventsAsync(CancellationToken ct) => 
            _eventRepository.GetAllEventsAsync(ct);

        public Task<Event?> GetEventByIdAsync(string eventId, CancellationToken ct) => 
            _eventRepository.GetEventByIdAsync(eventId, ct);

        public Task<bool> CreateEventAsync(Event eventItem, CancellationToken ct) =>
            _eventRepository.CreateEventAsync(eventItem, ct);
    }
}
