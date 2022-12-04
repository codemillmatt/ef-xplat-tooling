using Microsoft.EntityFrameworkCore;
using GlobalTicket.Events.Api.Models;

namespace GlobalTicket.Events.Api.Data;

public class EventContext : DbContext
{
    public EventContext(DbContextOptions<EventContext> options) : base(options)
    {        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.LogTo(Console.WriteLine);

    public DbSet<EventInfo> Events => Set<EventInfo>();
    public DbSet<EventType> EventTypes => Set<EventType>();
    public DbSet<Venue> Venues => Set<Venue>();    
}

public static class Extensions
{
    public static void CreateDbIfNotExists(this IHost host)
    {
        using var scope = host.Services.CreateScope();

        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<EventContext>();
        context.Database.EnsureCreated();
        DbInitializer.Initialize(context); 
    }
}