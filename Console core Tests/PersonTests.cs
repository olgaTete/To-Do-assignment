using System;
using Console_core.Models.Models;
using Xunit;


namespace Console_core_Tests
{
        public class PersonTests
        {
            [Fact]
            public void Person_CanBeCreated_WithValidParameters()
            {
                var person = new Person(1, "John", "Doe");
                Assert.Equal(1, person.Id);
                Assert.Equal("John", person.FirstName);
                Assert.Equal("Doe", person.LastName);
            }

            [Fact]
            public void FirstName_CannotBeNullOrEmpty()
            {
                Assert.Throws<ArgumentException>(() => new Person(1, null, "Doe"));
                Assert.Throws<ArgumentException>(() => new Person(1, "", "Doe"));
            }

            [Fact]
            public void LastName_CannotBeNullOrEmpty()
            {
                Assert.Throws<ArgumentException>(() => new Person(1, "John", null));
                Assert.Throws<ArgumentException>(() => new Person(1, "John", ""));
            }

            [Fact]
            public void CanSetFirstName()
            {
                var person = new Person(1, "John", "Doe");
                person.FirstName = "Jane";
                Assert.Equal("Jane", person.FirstName);
            }

            [Fact]
            public void CanSetLastName()
            {
                var person = new Person(1, "John", "Doe");
                person.LastName = "Smith";
                Assert.Equal("Smith", person.LastName);
            }
        }
}