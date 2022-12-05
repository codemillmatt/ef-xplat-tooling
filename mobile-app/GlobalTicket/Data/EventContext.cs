using System;
using Microsoft.EntityFrameworkCore;
using GlobalTicket.Models;

namespace GlobalTicket.Data
{
	public class EventContext : DbContext
	{
		public EventContext(DbContextOptions<EventContext> options) : base(options)
		{
		}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.LogTo(Console.WriteLine);
        }

        public DbSet<EventInfo> Events => Set<EventInfo>();
        public DbSet<EventType> EventTypes => Set<EventType>();
        public DbSet<Venue> Venues => Set<Venue>();
    }
}

