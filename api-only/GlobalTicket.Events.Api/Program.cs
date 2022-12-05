using Microsoft.AspNetCore.Mvc;
using GlobalTicket.Events.Api.Services;
using GlobalTicket.Events.Api.Models;
using GlobalTicket.Events.Api.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSqlite<EventContext>("Data Source=events.db");

builder.Services.AddTransient<EventService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// get all events
app.MapGet("/events", async ([FromServices]EventService eventService) =>
{
    return await eventService.GetAllEventsAsync();
})
.WithName("GetAllEvents")
.Produces<EventInfo>(StatusCodes.Status200OK);

// create a new event
app.MapPost("/events", async ([FromBody]EventInfo eventInfo, [FromServices]EventService eventService) => {
    var newEventInfo = await eventService.CreateAsync(eventInfo);

    return Results.CreatedAtRoute(routeName: "CreateNewEvent", value: newEventInfo);    
})
.WithName("CreateNewEvent")
.Produces<EventInfo>(StatusCodes.Status201Created);

// delete an event
app.MapDelete("/events/{id}", async (int id, [FromServices]EventService eventService) => {
    var eventInfo = await eventService.GetByIdAsync(id);

    if (eventInfo is not null)
    {
        await eventService.DeleteAsync(id);
        return Results.Ok();
    }   
    else
    {
        return Results.NotFound();
    }  
})
.WithName("DeleteEvent")
.Produces(StatusCodes.Status200OK)
.Produces(StatusCodes.Status404NotFound);

// update an event venue
app.MapPut("/events/{id}", async (int id, [FromQuery]int venueId, [FromServices]EventService eventService) => {
    var eventToUpdate = await eventService.GetByIdAsync(id);

    if (eventToUpdate is null)
        return Results.NotFound();
    
    await eventService.UpdateVenueAsync(id, venueId);

    return Results.NoContent();
})
.WithName("UpdateEventVenue")
.Produces(StatusCodes.Status204NoContent)
.Produces(StatusCodes.Status404NotFound);

// this will doubly make sure the database exists, even if you don't run the migrations
// it will also populate the data. It's here for safe keeping
app.CreateDbIfNotExists();

app.Run();
