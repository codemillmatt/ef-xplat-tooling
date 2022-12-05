using GlobalTicket.Events.Api.Services;

namespace GlobalTicket.Events.Tests;

public class TicketTests : IClassFixture<EventsDatabaseFixture>
{
    public EventsDatabaseFixture Fixture { get; }

    public TicketTests(EventsDatabaseFixture fixture)
    {
        Fixture = fixture;
    }

    [Fact]
    public async Task VerifySingleTicket()
    {
        using var context = Fixture.CreateContext();

        EventService eventService = new(context);

        var singleEvent = await eventService.GetByIdAsync(2);

        Assert.Equal("Felines", singleEvent?.Name);
    }

    [Fact]
    public async Task DeleteTicketTest()
    {
        using var context = Fixture.CreateContext();

        EventService eventService = new(context);

        var eventToBeDeleted = await eventService.GetByIdAsync(1);

        await eventService.DeleteAsync(1);

        var events = await eventService.GetAllEventsAsync();

        Assert.DoesNotContain(eventToBeDeleted, events);
    }
}