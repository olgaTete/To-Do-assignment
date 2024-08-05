using System;
using Console_core.Models.Models;
using Xunit;

namespace Console_core_Tests
{
    public class TodoTests
    {
        [Fact]
        public void Todo_CanBeCreated_WithValidParameters()
        {
            var todo = new Todo(1, "Test description");
            Assert.Equal(1, todo.Id);
            Assert.Equal("Test description", todo.Description);
            Assert.False(todo.Done);
            Assert.Null(todo.Assignee);
        }

        [Fact]
        public void Description_CannotBeNullOrEmpty()
        {
            Assert.Throws<ArgumentException>(() => new Todo(1, null));
            Assert.Throws<ArgumentException>(() => new Todo(1, ""));
        }

        [Fact]
        public void CanSetDescription()
        {
            var todo = new Todo(1, "Test description");
            todo.Description = "Updated description";
            Assert.Equal("Updated description", todo.Description);
        }

        [Fact]
        public void CanSetDone()
        {
            var todo = new Todo(1, "Test description");
            todo.Done = true;
            Assert.True(todo.Done);
        }

        [Fact]
        public void CanSetAssignee()
        {
            var todo = new Todo(1, "Test description");
            var person = new Person(1, "John", "Doe");
            todo.Assignee = person;
            Assert.Equal(person, todo.Assignee);
        }
    }
}
