using Microsoft.EntityFrameworkCore;
using GlobalTicket.Events.Api.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace GlobalTicket.Events.Api.Data;

public class EventContext : DbContext
{
    //readonly StreamWriter _logStream = new StreamWriter("log.csv", append: true);
    
    public EventContext(DbContextOptions<EventContext> options) : base(options)
    {        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        optionsBuilder.LogTo(Console.WriteLine);

        // Uncomment the below (and comment the line above) to log to a file
        // optionsBuilder.LogTo(msg => _logStream.WriteLine(CSVifyLogMessage(msg)),
        //     events: new[] { RelationalEventId.CommandExecuted }
        // ).EnableSensitiveDataLogging();    

        // Uncomment the line below to use the compiled model
        //optionsBuilder.UseModel(GlobalTicket.Events.Api.Compiled.EventContextModel.Instance);  
    }

    // Uncomment the lines below if logging to a CSV file
    // public override void Dispose()
    // {
    //     base.Dispose();

    //     _logStream.Dispose();
    // }

    // public async override ValueTask DisposeAsync()
    // {
    //     await base.DisposeAsync();

    //     await _logStream.DisposeAsync();
    // }

    public DbSet<EventInfo> Events => Set<EventInfo>();
    public DbSet<EventType> EventTypes => Set<EventType>();
    public DbSet<Venue> Venues => Set<Venue>();    

    // this is used to take a log message and put it into a CSV format
    string CSVifyLogMessage(string msg)
    {
        int currentStart = 0;
        int currentEnd = 0;
        int totalLength = 0;

        string? infoType;
        string? date;
        string? msgType;
        string? message;

        // info: start to colon
        currentEnd = msg.IndexOf(":");
        totalLength = currentEnd - currentStart;
        infoType = msg.Substring(currentStart, totalLength);

        // date: end of start + 1 to period + 3
        currentStart = currentEnd + 2;
        currentEnd = msg.IndexOf(".", currentStart) + 4;
        totalLength = currentEnd - currentStart;
        date = msg.Substring(currentStart, totalLength);

        // type: end of date + 1 to end parenthesis
        currentStart = currentEnd + 1;
        currentEnd = msg.IndexOf(Environment.NewLine, currentStart);
        totalLength = currentEnd - currentStart;
        msgType = msg.Substring(currentStart, totalLength);

        // msg: end of type + 2 to end
        currentStart = currentEnd + 7;
        message = msg.Substring(currentStart).Replace(",", string.Empty).Replace("\"", string.Empty).Replace(Environment.NewLine, string.Empty);

        return $"{infoType},{date},{msgType},\"{message}\"";
    }

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