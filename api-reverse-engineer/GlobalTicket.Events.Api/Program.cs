using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.MapGet("/events", async() => {
    await Task.CompletedTask;
    
    // var context = new GlobalTicket.Events.Api.Data.EventContext(
    //     app.Configuration["ConnectionStrings:EventsSql"]
    // );

    // return await context.Events.AsNoTracking().ToListAsync();
});

app.Run();
