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
    public class PeopleServiceTests
    {
        [Fact]
        public void Size_ShouldReturnZero_WhenArrayIsEmpty()
        {
            // Arrange
            PeopleService peopleService = new PeopleService();
            peopleService.Clear();

            // Act
            int size = peopleService.Size();

            // Assert
            Assert.Equal(0, size);
        }

        [Fact]
        public void FindAll_ShouldReturnEmptyArray_WhenNoPeople()
        {
            // Arrange
            PeopleService peopleService = new PeopleService();
            peopleService.Clear();

            // Act
            Person[] people = peopleService.FindAll();

            // Assert
            Assert.Empty(people);
        }

        [Fact]
        public void FindById_ShouldReturnCorrectPerson_WhenPersonExists()
        {
            // Arrange
            PeopleService peopleService = new PeopleService();
            peopleService.Clear();
            Person person = peopleService.CreatePerson("John", "Doe");

            // Act
            Person foundPerson = peopleService.FindById(person.Id);

            // Assert
            Assert.Equal(person, foundPerson);
        }

        [Fact]
        public void CreatePerson_ShouldAddPersonToArray()
        {
            // Arrange
            PeopleService peopleService = new PeopleService();
            peopleService.Clear();
            int initialSize = peopleService.Size();

            // Act
            peopleService.CreatePerson("John", "Doe");
            int newSize = peopleService.Size();

            // Assert
            Assert.Equal(initialSize + 1, newSize);
        }

        [Fact]
        public void Clear_ShouldEmptyTheArray()
        {
            // Arrange
            PeopleService peopleService = new PeopleService();
            peopleService.CreatePerson("John", "Doe");

            // Act
            peopleService.Clear();
            int size = peopleService.Size();

            // Assert
            Assert.Equal(0, size);
        }
        public void RemovePerson_ShouldRemovePersonFromArray()
        {
            // Arrange
            PeopleService peopleService = new PeopleService();
            peopleService.Clear();
            Person person1 = peopleService.CreatePerson("John", "Doe");
            Person person2 = peopleService.CreatePerson("Jane", "Doe");

            // Act
            peopleService.RemovePerson(person1.Id);
            Person[] remainingPeople = peopleService.FindAll();

            // Assert
            Assert.DoesNotContain(person1, remainingPeople);
            Assert.Contains(person2, remainingPeople);
        }
    }
}
