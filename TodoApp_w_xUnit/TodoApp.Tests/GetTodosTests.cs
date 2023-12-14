using TodoApp.Models;
using TodoApp.Controllers;

namespace TodoApp.Tests
{
    public class GetTodosTests
    {
        [Fact]
        public void Should_Return_One_Todo()
        {
            // Arrange
            var todoList = new List<Todo>
            {
                new Todo
                {
                    Title = "Test",
                    Description = "Test",
                    IsDone = true
                }
            }
;
            var controller = new TodoController(todoList);

            // Act
            var todos = controller.GetTodos();

            //Assert
            Assert.Equal(todoList.Count, todos.Count);
        }

        [Fact]
        public void Should_Return_Two_Todos()
        {
            // Arrange
             var controller = new TodoController();

            // Act
            var todos = controller.GetTodos();

            //Assert
            Assert.Equal(2, todos.Count);
        }
    }
}