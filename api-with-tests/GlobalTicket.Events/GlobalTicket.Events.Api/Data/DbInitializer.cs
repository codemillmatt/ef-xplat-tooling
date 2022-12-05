using GlobalTicket.Events.Api.Models;

namespace GlobalTicket.Events.Api.Data;

public static class DbInitializer
{
    public static void Initialize(EventContext context)
    {
        if (context.Events.Any() && context.EventTypes.Any() && context.Venues.Any())
            return;

        var concertHall = new Venue { Capacity = 1000, City = "Seattle", Name = "Global Ticket Hall" };
        var theater = new Venue { Capacity = 500, City = "Seattle", Name = "The Global Ticket Theater" };
        var ballField = new Venue { Capacity = 45000, City = "Seattle", Name = "Global Ticket Field" };        

        var baseballGame = new EventType { Name = "Baseball" };
        var americanFootballGame = new EventType { Name = "Football" };
        var concert = new EventType { Name = "Concert" };
        var play = new EventType { Name = "Musical" };

        var rachman = new EventInfo {
            Artist = "Global Ticket Symphony Orchestra",
            Description = "GTS plays Rachman Symphony No 1",
            EventDate = DateTime.Now.AddDays(14),
            EventType = concert,
            Name = "Rachman Symphony No 1",
            Venue = concertHall
        };

        var felines = new EventInfo {
            Artist = "Global Ticket Theater Company",
            Description = "GTTC presents Felines",
            EventDate = DateTime.Now.AddDays(45),
            EventType = play,
            Name = "Felines",
            Venue = theater
        };

        var baseballSeasonTickets = new EventInfo {
            Artist = "Global Ticket Diamonds",
            Description = "Season Tickets",
            EventDate = DateTime.Now.AddDays(7),
            EventType = baseballGame,
            Name = "Season tickets for the GT Diamonds",
            Venue = ballField
        };

        var footballGame = new EventInfo { 
            Artist = "Global Ticket GridIron",
            Description = "Global Ticket GridIron Bowl",
            EventDate = DateTime.Now.AddDays(120),
            EventType = americanFootballGame,
            Name = "Global Ticket GridIron Bowl",
            Venue = ballField
        };
    
        var events = new EventInfo[] { rachman, felines, baseballSeasonTickets, footballGame };

        context.Events.AddRange(events);
        context.SaveChanges();
    }
}