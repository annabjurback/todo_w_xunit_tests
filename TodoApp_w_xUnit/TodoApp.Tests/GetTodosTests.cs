using TodoApp.Models;
using TodoApp.Controllers;

namespace TodoApp.Tests
{
    public class GetTodosTests
    {
        [Fact]
        public void Should_Return_Todolist_With_Same_Data_As_Stored()
        {
            // Arrange
            var storage = new DataStorage();
            storage.Todos.Add(
                new Todo
                {
                    Title = "Test",
                    Description = "Test",
                    IsDone = true
                }
            );
;
            var controller = new TodoController(storage);

            // Act
            var response = controller.GetTodos();

            //Assert
            Assert.Equal(storage.Todos.Count, response.Count);
            Assert.Equal(storage.Todos[0].ID, response[0].ID);
            Assert.Equal(storage.Todos[0].Title, response[0].Title);
            Assert.Equal(storage.Todos[0].Description, response[0].Description);
            Assert.Equal(storage.Todos[0].IsDone, response[0].IsDone);
        }
    }
}