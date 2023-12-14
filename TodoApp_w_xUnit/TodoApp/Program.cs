using Microsoft.EntityFrameworkCore;
using TodoApp.Data;

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
			builder.Services.AddDbContext<TodoContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
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

			using (var scope = app.Services.CreateScope())
			{
				var services = scope.ServiceProvider;
				var context = services.GetRequiredService<TodoContext>();
				SampleData.CreateSampleData(context);
			}

			app.Run();
		}
	}
}