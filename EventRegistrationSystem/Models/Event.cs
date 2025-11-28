namespace EventRegistrationSystem.Models;

public class Event
{
    public required string Id { get; set; }
    public required string CreatorId { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string Location { get; set; }
    public required DateTime StartDate { get; set; }
    public required DateTime EndDate { get; set; }
    public required DateTime CreatedAt { get; set; }
}
