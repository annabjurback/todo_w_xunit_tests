using TodoApp.Models;
using TodoApp.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace TodoApp.Tests
{
	public class DeleteTodoTests
	{
		string title = "Mock title";
		[Fact]
		public void ShouldReturn_Ok_And_StorageSize_ShouldBeLess()
		{
			// Arrange
			var storage = new DataStorage();
			var controller = new TodoController(storage);
			int x = 5;
			string xString = x.ToString();
			for (int i = 1; i <= x; i++)
			{
				controller.PostTodo(title, null);
			}

			// Act
			var response = controller.DeleteTodo(xString);

			//Assert
			var result = response as StatusCodeResult;
			Assert.Equal(200, result!.StatusCode);
			Assert.Equal(x - 1, storage.Todos.Count);
		}

		[Fact]
		public void ShouldReturn_ArgumentNullExeption_If_RequestIsNull()
		{
			// Arrange
			var storage = new DataStorage();
			var controller = new TodoController(storage);

			//Assert (with built-in Act)
			Assert.Throws<ArgumentNullException>(() => controller.DeleteTodo(null!));
		}

		[Fact]
		public void ShouldReturn_BadRequest_If_RequestParam_CannotBeConvertedTo_Int()
		{
			// Arrange
			var storage = new DataStorage();
			var controller = new TodoController(storage);
			controller.PostTodo(title, null);

			//Act
			var response = controller.DeleteTodo("hello");

			// Assert
			var result = response as StatusCodeResult;
			Assert.Equal(400, result!.StatusCode);
		}
	}
}
