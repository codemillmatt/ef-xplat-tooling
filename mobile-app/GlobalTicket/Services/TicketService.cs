using System;
using GlobalTicket.Data;
using GlobalTicket.Models;
using Microsoft.EntityFrameworkCore;

namespace GlobalTicket.Services
{
	public class TicketService
	{
		private readonly EventContext _context;

		public TicketService(EventContext context)
		{
			_context = context;
		}

		public IEnumerable<EventInfo> GetAllEvents()
		{
			return _context.Events
				.Include(ei => ei.EventType)
				.Include(ei => ei.Venue)
				.AsNoTracking()
				.ToList();
		}


	}
}

