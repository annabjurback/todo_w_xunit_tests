using Microsoft.AspNetCore.Mvc;
using TodoApp.Models;

namespace TodoApp.Controllers
{
    [ApiController]
    public class TodoController : Controller
    {
        // sample data
        List<Todo> _todos = new List<Todo>
        {
            new Todo
            {
                Title = "Do first",
                Description = "Tidy up",
                IsDone = true
            },

            new Todo
            {
                Title = "Do second",
                Description = "Decorate for christmas",
                IsDone = false
            }
        };
        // constructor only used for testing
        public TodoController()
        {
        }
        // constructor only used for testing
        public TodoController(List<Todo> todos)
        {
            _todos = todos;
        }

        [HttpGet("/all")]
        public List<Todo> GetTodos()
        {
            return _todos;
        }
    }
}
