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

        [Fact]
        public void FindByDoneStatus_ShouldReturnTodosWithMatchingStatus()
        {
            // Arrange
            TodoService todoService = new TodoService();
            todoService.Clear();
            Person assignee = new Person(PersonSequencer.NextPersonId(), "John", "Doe");
            Todo todo1 = todoService.CreateTodoItem("Task 1", true, assignee);
            Todo todo2 = todoService.CreateTodoItem("Task 2", false, assignee);

            // Act
            Todo[] doneTodos = todoService.FindByDoneStatus(true);
            Todo[] notDoneTodos = todoService.FindByDoneStatus(false);

            // Assert
            Assert.Contains(todo1, doneTodos);
            Assert.Contains(todo2, notDoneTodos);
        }

        [Fact]
        public void FindByAssignee_ShouldReturnTodosWithMatchingAssigneeId()
        {
            // Arrange
            TodoService todoService = new TodoService();
            todoService.Clear();
            Person assignee1 = new Person(PersonSequencer.NextPersonId(), "John", "Doe");
            Person assignee2 = new Person(PersonSequencer.NextPersonId(), "Jane", "Doe");
            Todo todo1 = todoService.CreateTodoItem("Task 1", true, assignee1);
            Todo todo2 = todoService.CreateTodoItem("Task 2", false, assignee2);

            // Act
            Todo[] todosForAssignee1 = todoService.FindByAssignee(assignee1.Id);
            Todo[] todosForAssignee2 = todoService.FindByAssignee(assignee2.Id);

            // Assert
            Assert.Contains(todo1, todosForAssignee1);
            Assert.Contains(todo2, todosForAssignee2);
        }

        [Fact]
        public void FindByAssignee_ShouldReturnTodosWithMatchingAssignee()
        {
            // Arrange
            TodoService todoService = new TodoService();
            todoService.Clear();
            Person assignee1 = new Person(PersonSequencer.NextPersonId(), "John", "Doe");
            Person assignee2 = new Person(PersonSequencer.NextPersonId(), "Jane", "Doe");
            Todo todo1 = todoService.CreateTodoItem("Task 1", true, assignee1);
            Todo todo2 = todoService.CreateTodoItem("Task 2", false, assignee2);

            // Act
            Todo[] todosForAssignee1 = todoService.FindByAssignee(assignee1);
            Todo[] todosForAssignee2 = todoService.FindByAssignee(assignee2);

            // Assert
            Assert.Contains(todo1, todosForAssignee1);
            Assert.Contains(todo2, todosForAssignee2);
        }
        [Fact]
        public void FindUnassignedTodoItems_ShouldReturnTodosWithNoAssignee()
        {
            // Arrange
            TodoService todoService = new TodoService();
            todoService.Clear();
            Person assignee = new Person(PersonSequencer.NextPersonId(), "John", "Doe");
            Todo todo1 = todoService.CreateTodoItem("Task 1", true, null);
            Todo todo2 = todoService.CreateTodoItem("Task 2", false, assignee);

            // Act
            Todo[] unassignedTodos = todoService.FindUnassignedTodoItems();

            // Assert
            Assert.Contains(todo1, unassignedTodos);
            Assert.DoesNotContain(todo2, unassignedTodos);
        }
    }
}
