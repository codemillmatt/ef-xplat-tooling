using GlobalTicket.Data;
using GlobalTicket.Services;
using Microsoft.Extensions.Logging;

namespace GlobalTicket;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddSqlite<EventContext>("Data Source=events.db");
		builder.Services.AddTransient<TicketService>();
		builder.Services.AddTransient<MainPage>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		var app = builder.Build();

		app.CreateDbIfNotExists();

		return app;
	}
}

