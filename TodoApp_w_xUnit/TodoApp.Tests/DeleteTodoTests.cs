using TodoApp.Models;
using TodoApp.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace TodoApp.Tests
{
    public class DeleteTodoTests
    {
        [Fact]
        public void ShouldReturn_Ok_And_StorageSize_ShouldBeLess()
        {
            // Arrange
            var storage = new DataStorage();
            var controller = new TodoController(storage);
            string title = "Mock title";
            int x = 5;
            for (int i = 1; i <= x; i++)
            {
                controller.PostTodo(title, null);
            }

            // Act
            var response = controller.DeleteTodo(x.ToString());

            //Assert
            var result = response as StatusCodeResult;
            Assert.Equal(200, result!.StatusCode);
            Assert.Equal(x-1, storage.Todos.Count);
        }
    }
}
