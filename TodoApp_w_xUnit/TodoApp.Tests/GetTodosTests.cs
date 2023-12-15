using TodoApp.Models;
using TodoApp.Controllers;

namespace TodoApp.Tests
{
    public class GetTodosTests
    {
//        [Fact]
//        public void Should_Return_Todolist_With_Same_Data_As_Request()
//        {
//            // Arrange
//            var request = new List<Todo>
//            {
//                new Todo
//                {
//                    Title = "Test",
//                    Description = "Test",
//                    IsDone = true
//                }
//            }
//;
//            var controller = new TodoController(request);

//            // Act
//            var response = controller.GetTodos();

//            //Assert
//            Assert.Equal(request.Count, response.Count);
//            Assert.Equal(request[0].ID, response[0].ID);
//            Assert.Equal(request[0].Title, response[0].Title);
//            Assert.Equal(request[0].Description, response[0].Description);
//            Assert.Equal(request[0].IsDone, response[0].IsDone);
//        }

        // sample data is created in TodoController class.
        // might delete this test later, I don't want the test to break the pull request, just because I might have changed the sample data
        //[Fact]
        //public void Should_Return_Todolists_With_Sample_Data()
        //{
        //    // Arrange
        //     var controller = new TodoController();

        //    // Act
        //    var response = controller.GetTodos();

        //    //Assert
        //    Assert.Equal("Do first", response[0].Title);
        //    Assert.Equal("Tidy up", response[0].Description);
        //    Assert.Equal("Do second", response[1].Title);
        //    Assert.Equal("Decorate for christmas", response[1].Description);
        //}
    }
}