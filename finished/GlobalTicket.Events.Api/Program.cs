using GlobalTicket.Events.Api.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/events", () =>
{
    var ei = new EventInfo()
    {
        Artist = "Milwaukee Brewers",
        EventDate = DateTime.Today,
        EventType = new EventType { Name = "Baseball" }        
    };

    return Results.Ok(ei);
})
.WithName("GetAllEvents")
.Produces<EventInfo>(StatusCodes.Status200OK);

app.Run();
