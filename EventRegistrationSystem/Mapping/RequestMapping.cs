using EventRegistrationSystem.Models;
using EventRegistrationSystem.Models.Dtos;
using EventRegistrationSystem.Services.Interfaces;

namespace EventRegistrationSystem.Mapping;

public static class RequestMapping
{
    public static Event ToEvent(this CreateEventRequest request, string creatorId) =>
        new()
        {
            Id = Guid.NewGuid().ToString(),
            CreatorId = creatorId,
            Name = request.Name,
            Description = request.Description,
            Location = request.Location,
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            CreatedAt = DateTime.UtcNow
        };

    public static User ToUser(this RegisterUserRequest request, IEncryptionService encryptionService) =>
        new()
        {
            Id = Guid.NewGuid().ToString(),
            Name = request.Name,
            Email = request.Email,
            PasswordHash = encryptionService.HashPassword(request.Password, out var salt),
            Salt = salt        
        };

    public static Registration ToEventRegistration(this RegisterEventRequest request, string eventId) =>
        new()
        {
            Id = Guid.NewGuid().ToString(),
            EventId = eventId,
            Name = request.Name,
            Email = request.Email,
            PhoneNumber = request?.PhoneNumber,
            RegisteredAt = DateTime.UtcNow
        };

}
