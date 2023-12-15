//using Microsoft.EntityFrameworkCore;

namespace TodoApp
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllers();
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddRazorPages();
			// NOTE: update localhost address below if necessary
			builder.Services.AddHttpClient("BaseAddress", httpClient =>
			{
				if (builder.Environment.IsDevelopment())
				{
					httpClient.BaseAddress = new Uri("https://localhost:7004");
				}
			});

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			app.UseHttpsRedirection();
			app.UseStaticFiles();
			app.UseRouting();

			app.MapRazorPages();
			app.MapControllers();

			app.Run();
		}
	}
}