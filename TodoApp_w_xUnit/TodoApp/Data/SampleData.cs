using TodoApp.Models;

namespace TodoApp.Data
{
	public class SampleData
	{
		public static void CreateSampleData(TodoContext context)
		{
			// Add sample data if database is empty
			if (!context.Todos.Any())
			{
				context.Todos.Add(new Todo
				{
					Title = "Do first",
					Description = "Tidy up",
					IsDone = true
				});
				context.Todos.Add(new Todo
				{
					Title = "Do second",
					Description = "Decorate for christmas",
					IsDone = false
				});

				context.SaveChanges();
			}
		}
	}
}
