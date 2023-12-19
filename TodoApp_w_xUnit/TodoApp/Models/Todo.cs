using System.Security.Permissions;

namespace TodoApp.Models
{
	public class Todo
	{
		public int ID { get; set; }// =DataStorage.SetNextId();//Interlocked.Increment(ref nextId);
		public string? Title { get; set; }
		public string? Description { get; set; }
		public bool IsDone { get; set; }
	}
}
