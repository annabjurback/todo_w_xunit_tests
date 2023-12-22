using Microsoft.AspNetCore.Mvc;
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
		string title = "Mock title";

		[Fact]
		public void ShouldSet_IsDone_To_True()
		{
			//Arrange
			var storage = new DataStorage();
			var controller = new TodoController(storage);
			controller.PostTodo(title, null);
			controller.PostTodo(title, null);

			//Act
			var response = controller.EditIsDoneStatus("2");

			//Assert
			var result = response as StatusCodeResult;
			Assert.False(storage.Todos[0].IsDone);
			Assert.True(storage.Todos[1].IsDone);

		}

	}
}
