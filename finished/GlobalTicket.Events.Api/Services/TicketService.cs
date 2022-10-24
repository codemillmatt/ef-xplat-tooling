using GlobalTicket.Events.Api.Data;
using GlobalTicket.Events.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace GlobalTicket.Events.Api.Services;

public class EventService
{
    private readonly EventContext _context;

    public EventService(EventContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<EventInfo>> GetAllEventsAsync()
    {
        return await _context.Events
            .Include(ei => ei.EventType)
            .Include(ei => ei.Venue)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<EventInfo?> GetByIdAsync(int eventInfoId)
    {
        return await _context.Events.AsNoTracking().SingleOrDefaultAsync(ei => ei.Id == eventInfoId);
    }

    public async Task<EventInfo> CreateAsync(EventInfo eventInfo)
    {
        _context.Events.Add(eventInfo);

        await _context.SaveChangesAsync();

        return eventInfo;
    }

    public async Task DeleteAsync(int eventInfoId)
    {
        var eventInfo = await _context.Events.FindAsync(eventInfoId);

        if (eventInfo is not null)
        {
            _context.Events.Remove(eventInfo);
            await _context.SaveChangesAsync();
        }
    }

    public async Task UpdateVenueAsync(int eventInfoId, int venueId)
    {
        var eventInfo = await _context.Events.FindAsync(eventInfoId);
        var venue = await _context.Venues.FindAsync(venueId);

        if (eventInfo is null || venue is null)
        {
            throw new InvalidOperationException("Either event info or venue is null");
        }

        eventInfo.Venue = venue;

        await _context.SaveChangesAsync();
    }

}