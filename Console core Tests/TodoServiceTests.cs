using Xunit;
using Console_core.Date;
using Console_core.Models.Models;
using System;

namespace Console_core_Tests
{
    public class TodoServiceTests
    {

        [Fact]
        public void Size_ShouldReturnZero_WhenNoItems()
        {
            // Arrange
            TodoService todoService = new TodoService();
            todoService.Clear();
            // Act
            var size = todoService.Size();

            // Assert
            Assert.Equal(0, size);
        }

        [Fact]
        public void CreateTodoItem_ShouldAddNewItem()
        {
            // Arrange
            TodoService todoService = new TodoService();
            todoService.Clear();
            var description = "Test Description";
            var done = false;
            var assignee = new Person { FirstName = "John", LastName = "Doe" };

            // Act
            var todo = todoService.CreateTodoItem(description, done, assignee);

            // Assert
            Assert.Equal(1, todoService.Size());
            Assert.Equal(description, todo.Description);
            Assert.Equal(done, todo.Done);
            Assert.Equal(assignee, todo.Assignee);
        }

        [Fact]
        public void FindById_ShouldReturnCorrectItem()
        {
            // Arrange
            TodoService todoService = new TodoService();
            todoService.Clear();
            var todo1 = todoService.CreateTodoItem("Test 1", false, new Person { FirstName = "John", LastName = "Doe" });
            var todo2 = todoService.CreateTodoItem("Test 2", true, new Person { FirstName = "Jane", LastName = "Doe" });

            // Act
            var result = todoService.FindById(todo1.Id);

            // Assert
            Assert.Equal(todo1, result);
        }

        [Fact]
        public void FindByDoneStatus_ShouldReturnCorrectItems()
        {
            // Arrange
            TodoService todoService = new TodoService();
            todoService.Clear();
            todoService.CreateTodoItem("Test 1", false, new Person { FirstName = "John", LastName = "Doe" });
            var todo2 = todoService.CreateTodoItem("Test 2", true, new Person { FirstName = "Jane", LastName = "Doe" });

            // Act
            var result = todoService.FindByDoneStatus(true);

            // Assert
            Assert.Single(result);
            Assert.Contains(todo2, result);
        }

        [Fact]
        public void FindUnassignedTodoItems_ShouldReturnCorrectItems()
        {
            // Arrange
            TodoService todoService = new TodoService();
            todoService.Clear();
            var todo1 = todoService.CreateTodoItem("Test 1", false, null);
            todoService.CreateTodoItem("Test 2", true, new Person { FirstName = "Jane", LastName = "Doe" });

            // Act
            var result = todoService.FindUnassignedTodoItems();

            // Assert
            Assert.Single(result);
            Assert.Contains(todo1, result);
        }

        [Fact]
        public void RemoveTodoItem_ShouldDeleteItem()
        {
            // Arrange
            TodoService todoService = new TodoService();
            todoService.Clear();
            var todo = todoService.CreateTodoItem("Test", false, new Person { FirstName = "John", LastName = "Doe" });

            // Act
            todoService.RemoveTodoItem(todo.Id);

            // Assert
            Assert.Equal(0, todoService.Size());
            Assert.Null(todoService.FindById(todo.Id));
        }
    }
}

