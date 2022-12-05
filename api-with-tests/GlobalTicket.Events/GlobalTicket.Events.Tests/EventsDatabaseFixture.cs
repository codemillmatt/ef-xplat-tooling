using GlobalTicket.Events.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace GlobalTicket.Events.Tests;

public class EventsDatabaseFixture 
{
    private static readonly object _lock = new();
    private static bool _dbInitialized = false;

    public EventsDatabaseFixture()
    {
        lock (_lock)
        {
            if (!_dbInitialized)
            {
                using var context = CreateContext();
                
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                DbInitializer.Initialize(context);
            }

            _dbInitialized = true;
        }
    }

    public EventContext CreateContext() => 
        new EventContext(new DbContextOptionsBuilder<EventContext>()
            .UseSqlite("Data Source=events.db")
            .Options);
}