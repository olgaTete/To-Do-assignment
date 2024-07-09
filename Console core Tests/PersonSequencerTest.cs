using Console_core.Date;
using Xunit;

namespace Console_core_Tests
{
    public class PersonSequencerTest
    {
        [Fact]
        public void NextPersonId_ShouldIncrementAndReturnNextValue()
        {
            // Arrange
            PersonSequencer.Reset();

            // Act
            int firstId = PersonSequencer.NextPersonId();
            int secondId = PersonSequencer.NextPersonId();

            // Assert
            Assert.Equal(1, firstId);
            Assert.Equal(2, secondId);
        }
        [Fact]
        public void Reset_ShouldSetPersonIdToZero()
        {
            // Arrange
            PersonSequencer.NextPersonId(); // Increment the personId
            PersonSequencer.NextPersonId(); // Increment again

            // Act
            PersonSequencer.Reset();
            int resetId = PersonSequencer.NextPersonId();

            // Assert
            Assert.Equal(1, resetId);
        }
        private static int NextPersonId()
        {
            throw new NotImplementedException();
        }

        private static void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
