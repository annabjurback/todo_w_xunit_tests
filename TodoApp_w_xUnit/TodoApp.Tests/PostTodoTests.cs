using TodoApp.Models;
using TodoApp.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace TodoApp.Tests
{
    public class PostTodoTests
    {
        [Fact]
        public void ShouldReturn_Ok_And_StorageShouldHave_ListWithSameData_As_Request()
        {
            //Arrange
            Todo.nextId = 0;
            var _storage = new DataStorage();
            var _controller = new TodoController(_storage);
            string title = "Title";
            string description = "Description";

            // Act
            var response = _controller.PostTodo(title, description);

            // Assert
            var result = response as StatusCodeResult;
            Assert.Equal(200, result!.StatusCode);

            Assert.Equal(title, _storage.Todos![0].Title);
            Assert.Equal(description, _storage.Todos[0].Description);
            Assert.Equal(1, _storage.Todos[0].ID);
        }

        [Fact]
        public void ShouldReturn_Ok_And_StorageShouldHaveListOfTodos_With_ConsecutiveIds()
        {
            //Arrange
            Todo.nextId = 0; //eller skriv en metod i Todo som heter ResetnextID().. typ
            var _storage = new DataStorage();
            var _controller = new TodoController(_storage);
            string title = "title";

            //Act
            int x = 5;
            for (int i = 1; i < x; i++)
            {
                _controller.PostTodo(title, null);
            }
            var response = _controller.PostTodo(title, null);

            //Assert
            var result = response as StatusCodeResult;
            Assert.Equal(200, result!.StatusCode);

            Assert.Equal(x, _storage.Todos.Count);
            for (int i = 1; i <= _storage.Todos.Count; i++)
            {
                Assert.Equal(i, _storage.Todos[i - 1].ID);
            }
        }

        [Fact]
        public void ShouldReturn_BadRequest_And_StorageShouldOnlyContainOneItem_If_ParametersOfSecondPostRequest_Are_Null()
        {
            // Arrange
            Todo.nextId = 0;
            var _storage = new DataStorage();
            var _controller = new TodoController(_storage);
            string title1 = "title";
            string description1 = "description";
            string? title2 = null;
            string? description2 = null;

            // Act
            _controller.PostTodo(title1, description1);
            var response = _controller.PostTodo(title2, description2);

            // Assert
            var result = response as StatusCodeResult;
            Assert.Equal(400, result!.StatusCode);

            Assert.Single(_storage.Todos);
        }
    }
}
