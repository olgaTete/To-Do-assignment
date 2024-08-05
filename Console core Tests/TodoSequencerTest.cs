using System;
using Console_core.Date;
using Xunit;

namespace Console_core_Tests
{
    public class TodoSequencerTest
    {
        [Fact]
        public void NextTodoId_ShouldReturnIncrementedValues()
        {
            // Arrange
            TodoSequencer.Reset();

            // Act
            int firstId = TodoSequencer.NextTodoId();
            int secondId = TodoSequencer.NextTodoId();

            // Assert
            Assert.Equal(1, firstId);
            Assert.Equal(2, secondId);
        }

        [Fact]
        public void Reset_ShouldSetTodoIdToZero()
        {
            // Arrange
            TodoSequencer.NextTodoId(); // Increment once to change the default value

            // Act
            TodoSequencer.Reset();
            int resetId = TodoSequencer.NextTodoId();

            // Assert
            Assert.Equal(1, resetId); // After reset, the next id should be 1
        }
    }
}
