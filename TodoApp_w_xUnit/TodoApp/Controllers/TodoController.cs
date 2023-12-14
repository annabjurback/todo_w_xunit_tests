using Microsoft.AspNetCore.Mvc;
using TodoApp.Data;
using TodoApp.Models;

namespace TodoApp.Controllers
{
	//[Route("/all")]
	[ApiController]
	public class TodoController : Controller
	{

		private readonly TodoContext _context;

		public TodoController(TodoContext context)
		{
			_context = context;
		}

		[HttpGet("/all")]
		public List<Todo> GetTodos()
		{
			return _context.Todos.ToList();
		}
	}
}
