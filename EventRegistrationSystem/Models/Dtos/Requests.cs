using System.ComponentModel.DataAnnotations;

namespace EventRegistrationSystem.Models.Dtos;

public record RegisterEventRequest(
    [Required][StringLength(100)] string Name, 
    [Required][EmailAddress] string Email, 
    [Phone] string? PhoneNumber);

public record CreateEventRequest(
    [Required][StringLength(100)] string Name,
    [Required][StringLength(500)] string Description,
    [Required][StringLength(200)] string Location,
    [Required] DateTime StartDate,
    [Required] DateTime EndDate);

public record RegisterUserRequest(
    [Required][StringLength(100)] string Name,
    [Required][StringLength(100)] string Email,
    [Required][StringLength(100, MinimumLength = 6)] string Password);

public record LoginUserRequest(
    [Required][StringLength(100)] string Email,
    [Required][StringLength(100, MinimumLength = 6)] string Password);
