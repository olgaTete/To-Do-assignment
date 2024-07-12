using Console_core.Date;
using Console_core.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Console_core_Tests
{
    public class TodoServiceTests
    {
        [Fact]
        public void Size_ShouldReturnZero_WhenArrayIsEmpty()
        {
            // Arrange
            TodoService todoService = new TodoService();
            todoService.Clear();

            // Act
            int size = todoService.Size();

            // Assert
            Assert.Equal(0, size);
        }

        [Fact]
        public void FindAll_ShouldReturnEmptyArray_WhenNoTodoItems()
        {
            // Arrange
            TodoService todoService = new TodoService();
            todoService.Clear();

            // Act
            Todo[] todos = todoService.FindAll();

            // Assert
            Assert.Empty(todos);
        }

        [Fact]
        public void FindById_ShouldReturnCorrectTodoItem_WhenTodoItemExists()
        {
            // Arrange
            TodoService todoService = new TodoService();
            todoService.Clear();
            Person assignee = new Person(PersonSequencer.NextPersonId(), "John", "Doe");
            Todo todo = todoService.CreateTodoItem("Test Task", false, assignee);

            // Act
            Todo foundTodo = todoService.FindById(todo.Id);

            // Assert
            Assert.Equal(todo, foundTodo);
        }

        [Fact]
        public void CreateTodoItem_ShouldAddTodoToArray()
        {
            // Arrange
            TodoService todoService = new TodoService();
            todoService.Clear();
            int initialSize = todoService.Size();
            Person assignee = new Person(PersonSequencer.NextPersonId(), "John", "Doe");

            // Act
            todoService.CreateTodoItem("Test Task", false, assignee);
            int newSize = todoService.Size();

            // Assert
            Assert.Equal(initialSize + 1, newSize);
        }

        [Fact]
        public void Clear_ShouldEmptyTheArray()
        {
            // Arrange
            TodoService todoService = new TodoService();
            Person assignee = new Person(PersonSequencer.NextPersonId(), "John", "Doe");
            todoService.CreateTodoItem("Test Task", false, assignee);

            // Act
            todoService.Clear();
            int size = todoService.Size();

            // Assert
            Assert.Equal(0, size);
        }
    }
}
