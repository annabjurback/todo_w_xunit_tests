namespace TodoApp.Models
{
	public class Todo
	{
		static int nextId = 0;

		public int ID = Interlocked.Increment(ref nextId);
		public string? Title { get; set; }
		public string? Description { get; set; }
		public bool IsDone { get; set; }
	}
}
