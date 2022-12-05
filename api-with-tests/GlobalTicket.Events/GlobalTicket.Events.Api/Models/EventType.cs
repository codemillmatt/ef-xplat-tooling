using System.ComponentModel.DataAnnotations;

namespace GlobalTicket.Events.Api.Models;

public class EventType
{    
    public int Id { get; set; }

    public string Name { get; set; }
}