using System;
using Microsoft.EntityFrameworkCore;
using GlobalTicket.Models;

namespace GlobalTicket.Data
{
	public static class Extensions
	{
		public static void CreateDbIfNotExists(this MauiApp host)
		{
			using var scope = host.Services.CreateScope();

			var services = scope.ServiceProvider;
			var context = services.GetRequiredService<EventContext>();

			context.Database.EnsureCreated();

			DbInitializer.Initialize(context);			
		}
	}
}

