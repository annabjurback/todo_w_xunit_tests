using TodoApp.Models;
using TodoApp.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace TodoApp.Tests
{
    public class PostTodoTests
    {
        [Fact]
        public void Should_Return_List_With_Same_Data_As_Request()
        {
            //Arrange
            var controller = new TodoController(new DataStorage());
            string title = "Title";
            string description = "Description";

            // Act
            var response = controller.PostTodo(title, description);

            // Assert
            var result = response as ObjectResult;
            Assert.Equal(200, result!.StatusCode);
            Assert.IsType<List<Todo>>(result.Value);

            var todos = result.Value as List<Todo>;
            Assert.Equal(title, todos![0].Title);
            Assert.Equal(description, todos[0].Description);
            Assert.Equal(1, todos[0].ID);
        }

        [Fact]
        public void Should_Return_List_Of_Todos_With_Consecutive_Ids()
        {
            //Arrange
            var controller = new TodoController(new DataStorage());
            string title = "title";

            //Act
            int x = 5;
            for (int i = 1; i < x; i++)
            {
                controller.PostTodo(title, null);
            }
            var response = controller.PostTodo(title, null);

            //Assert
            var result = response as ObjectResult;
            Assert.Equal(200, result!.StatusCode);
            Assert.IsType<List<Todo>>(result.Value);

            var todos = result.Value as List<Todo>;
            Assert.Equal(x, todos!.Count);
            for (int i = 1; i <= todos.Count; i++)
            {
                Assert.Equal(i, todos[i - 1].ID);
            }
        }
    }
}
