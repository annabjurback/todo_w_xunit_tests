using Microsoft.AspNetCore.Mvc;
using TodoApp.Models;

namespace TodoApp.Controllers
{
    [ApiController]
    public class TodoController : Controller
    {
        // sample data
        private List<Todo> _todos;

        //constructor only used for testing the GetTodos method
        public TodoController()
        {
            _todos = new List<Todo>
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

        }

        [HttpGet("/all")]
        public List<Todo> GetTodos()
        {
            return _todos;
        }
    }
}
