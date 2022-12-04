using System.ComponentModel.DataAnnotations;

namespace GlobalTicket.Events.Api.Models;

public class Venue
{
    public int Id { get; set; }

    [Required]
    public string? Name { get; set; }

    [Required]
    public int Capacity { get; set; }

    [Required]
    public string? City { get; set; }
}