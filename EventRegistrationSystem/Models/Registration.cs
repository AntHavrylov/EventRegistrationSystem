namespace EventRegistrationSystem.Models;

public class Registration
{
    public required string Id { get; set; }
    public required string EventId { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public string? PhoneNumber { get; set; }
    public required DateTime RegisteredAt { get; set; }
}
