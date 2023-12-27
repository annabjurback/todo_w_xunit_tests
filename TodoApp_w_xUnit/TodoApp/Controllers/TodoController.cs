using Microsoft.AspNetCore.Mvc;
using TodoApp.Models;

namespace TodoApp.Controllers
{
    [ApiController]
    public class TodoController : Controller
    {
        private DataStorage _storage;

        public TodoController(DataStorage storage)
        {
            _storage = storage;
        }

        [HttpGet("/all")]
        public List<Todo> GetTodos()
        {
            return _storage.Todos;
        }

        [HttpPost("/add")]
        public IActionResult PostTodo(string? title, string? description)
        {

            if (title == null && description == null)
            {
                // since two parameters were null, not throwing an exception
                return BadRequest();
            }
            var todo = new Todo
            {
                ID = _storage.SetNextId(),
                Title = title,
                Description = description,
                IsDone = false
            };
            _storage.Todos.Add(todo);
            return Ok();
        }

        [HttpPost("/delete")]
        public IActionResult DeleteTodo(string id)
        {
            if(id is null)
            {
                throw new ArgumentNullException();
            }
            else
            {
                try
                {
                    int idToDelete = Convert.ToInt32(id);
                    var todoToRemove = _storage.Todos.Single(x => x.ID == idToDelete);
                    _storage.Todos.Remove(todoToRemove);
                }
                catch
                {
                    return BadRequest();
                }
            }
            return Ok();
        }

        [HttpPost("/invertisdonebool")]
        public IActionResult EditIsDoneStatus(string id)
        {
			if (id is null)
			{
				throw new ArgumentNullException();
			}
			else
			{
				try
				{
					int idToUpdate = Convert.ToInt32(id);
					var todoToUpdate = _storage.Todos.Single(x => x.ID == idToUpdate);
                    todoToUpdate.IsDone = !todoToUpdate.IsDone;

				}
				catch
				{
					return BadRequest();
				}
			}
			return Ok();
		}

    }
}
