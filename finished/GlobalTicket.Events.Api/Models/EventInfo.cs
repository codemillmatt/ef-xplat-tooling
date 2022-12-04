using System.ComponentModel.DataAnnotations;

namespace GlobalTicket.Events.Api.Models;

public class EventInfo
{
    public int Id { get; set; }

    [Required]
    public string? Name { get; set; }

    [Required]
    public DateTime EventDate { get; set; }

    [Required]
    public string? Artist { get; set; }

    public string? Description { get; set; }

    [Required]
    public Venue? Venue { get; set; }

    [Required]
    public EventType? EventType { get; set; }

}