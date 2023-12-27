using TodoApp.Models;
using TodoApp.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace TodoApp.Tests
{
	public class EditTodoTests
	{
		[Fact]
		public void ShouldReturn_Ok_AndStorageShouldBe_Updated()
		{
			//Arrange
			var storage = new DataStorage();
			var controller = new TodoController(storage);
			controller.PostTodo("title", "description");
			string idToUpdate = "1";

			//Act
			string newTitle = "new title";
			string newDescription = "new description";
			var response = controller.EditTodo(idToUpdate,newTitle,newDescription);

			//Assert
			var result = response as StatusCodeResult;
			Assert.Equal(200, result!.StatusCode);
			Assert.Equal(newTitle, storage.Todos[0].Title);
			Assert.Equal(newDescription, storage.Todos[0].Description);
		}


	}
}
