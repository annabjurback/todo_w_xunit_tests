using TodoApp.Models;
using TodoApp.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace TodoApp.Tests
{
	public class EditTodoTests
	{
		readonly string title = "title";
		readonly string description = "description";
		readonly string newTitle  = "new title";
		readonly string newDescription = "new description";
		[Fact]
		public void ShouldReturn_Ok_AndStorageShouldBe_Updated()
		{
			//Arrange
			var storage = new DataStorage();
			var controller = new TodoController(storage);
			controller.PostTodo(title, description);

			//Act
			var response = controller.EditTodo("1",newTitle,newDescription);

			//Assert
			var result = response as StatusCodeResult;
			Assert.Equal(200, result!.StatusCode);
			Assert.Equal(newTitle, storage.Todos[0].Title);
			Assert.Equal(newDescription, storage.Todos[0].Description);
		}

		[Fact]
		public void Should_ThrowException_If_AllParametersAreNull()
		{
			// Arrange
			var storage = new DataStorage();
			var controller = new TodoController(storage);
			controller.PostTodo(title, description);

			//Act and assert
			Assert.Throws<ArgumentNullException>(() => controller.EditTodo(null!, null!, null!));
			Assert.Throws<ArgumentNullException>(() => controller.EditTodo("1", null!, null!));
			Assert.Throws<ArgumentNullException>(() => controller.EditTodo(null!, newTitle, newDescription));
		}

		[Fact]
		public void ShouldReturn_BadRequest_If_IdIs_NotInt()
		{
			// Arrange
			var storage = new DataStorage();
			var controller = new TodoController(storage);
			controller.PostTodo(title, description);

			//Act
			var response = controller.EditTodo("forty-two",newTitle,newDescription);

			//Assert
			var result = response as StatusCodeResult;
			Assert.Equal(400, result!.StatusCode);
		}

		[Fact]
		public void ShouldReturn_BadRequest_If_IdDoesntExist()
		{
			// Arrange
			var storage = new DataStorage();
			var controller = new TodoController(storage);
			controller.PostTodo(title, description);

			//Act
			var response = controller.EditTodo("42", newTitle, newDescription);

			//Assert
			var result = response as StatusCodeResult;
			Assert.Equal(400, result!.StatusCode);
		}
	}
}
