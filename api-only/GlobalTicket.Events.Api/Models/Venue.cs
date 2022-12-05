namespace GlobalTicket.Events.Api.Models;

public class Venue 
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int Capacity { get; set; }

    public string? City { get; set; }

    public string? Country { get; set; }
}