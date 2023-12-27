using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Controllers;
using TodoApp.Models;

namespace TodoApp.Tests
{
	public class UpdateIsDoneTests
	{
		[Fact]
		public void ShouldSet_IsDone_To_True()
		{
			//Arrange
			string title = "Mock title";
			var storage = new DataStorage();
			var controller = new TodoController(storage);
			controller.PostTodo(title, null);
			controller.PostTodo(title, null);

			//Act
			var response = controller.EditIsDoneStatus("2");

			//Assert
			var result = response as StatusCodeResult;
			Assert.Equal(200, result!.StatusCode);
			Assert.False(storage.Todos[0].IsDone);
			Assert.True(storage.Todos[1].IsDone);

		}

		[Fact]
		public void ShouldThrowException_IfRequestIstNull()
		{
			//Arrange
			var storage = new DataStorage();
			var controller = new TodoController(storage);

			//Assert (and built-in act)
			Assert.Throws<ArgumentNullException>(() => controller.EditIsDoneStatus(null));

		}

		[Fact]
		public void ShouldReturn_BadRequest_If_RequestIsNotInt()
		{
			// Arange
			var storage = new DataStorage();
			var controller = new TodoController(storage);

			// Act
			var response = controller.EditIsDoneStatus("merry christmas");

			// Assert
			var result = response as StatusCodeResult;
			Assert.Equal(400, result!.StatusCode);
		}
		[Fact]
		public void ShouldReturn_BadRequest_If_RequestIntDoesNotExist()
		{
			// Arange
			var storage = new DataStorage();
			var controller = new TodoController(storage);

			// Act
			var response = controller.EditIsDoneStatus("1");

			// Assert
			var result = response as StatusCodeResult;
			Assert.Equal(400, result!.StatusCode);
		}
	}
}
