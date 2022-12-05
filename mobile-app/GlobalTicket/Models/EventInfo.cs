using System;
using System.ComponentModel.DataAnnotations;

namespace GlobalTicket.Models
{
	public class EventInfo
	{
        public int Id { get; set; }

        
        public string? Name { get; set; }

        
        public DateTime EventDate { get; set; }

        
        public string? Artist { get; set; }

        public string? Description { get; set; }

        
        public Venue? Venue { get; set; }

        
        public EventType? EventType { get; set; }
    }
}

