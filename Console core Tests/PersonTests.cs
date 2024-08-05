using System;
using Xunit;
using Console_core.Models.Models;

namespace Console_core_Tests
{
    public class PersonTests
    {
        [Fact]
        public void Constructor_ShouldInitializeProperties()
        {
            // Arrange
            int id = 1;
            string firstName = "John";
            string lastName = "Doe";

            // Act
            Person person = new Person(id, firstName, lastName);

            // Assert
            Assert.Equal(id, person.Id);
            Assert.Equal(firstName, person.FirstName);
            Assert.Equal(lastName, person.LastName);
        }

        [Fact]
        public void FirstName_ShouldThrowArgumentException_WhenNullOrEmpty()
        {
            // Arrange
            Person person = new Person();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => person.FirstName =

null);
            Assert.Throws<ArgumentException>(() => person.FirstName = "");
        }

        [Fact]
        public void LastName_ShouldThrowArgumentException_WhenNullOrEmpty()
        {
            // Arrange
            Person person = new Person();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => person.LastName = null);
            Assert.Throws<ArgumentException>(() => person.LastName = "");
        }

        [Fact]
        public void FirstName_ShouldSet_WhenValidValue()
        {
            // Arrange
            Person person = new Person();
            string firstName = "John";

            // Act
            person.FirstName = firstName;

            // Assert
            Assert.Equal(firstName, person.FirstName);
        }

        [Fact]
        public void LastName_ShouldSet_WhenValidValue()
        {
            // Arrange
            Person person = new Person();
            string lastName = "Doe";

            // Act
            person.LastName = lastName;

            // Assert
            Assert.Equal(lastName, person.LastName);
        }
    }
}