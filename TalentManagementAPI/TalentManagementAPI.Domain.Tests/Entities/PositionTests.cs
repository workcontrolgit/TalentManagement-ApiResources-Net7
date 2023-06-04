namespace TalentManagementAPI.Domain.Tests.Entities
{
    using AutoFixture;
    using Moq.AutoMock;
    using TalentManagementAPI.Domain.Entities;
    using Xunit;

    public class PositionTests
    {
        private Position _testClass;

        public PositionTests()
        {
            var mocker = new AutoMocker();
            _testClass = mocker.CreateInstance<Position>();
        }

        [Fact]
        public void CanSetAndGetPositionTitle()
        {
            // Arrange
            var fixture = new Fixture();

            var testValue = fixture.Create<string>();

            // Act
            _testClass.PositionTitle = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.PositionTitle);
        }

        [Fact]
        public void CanSetAndGetPositionNumber()
        {
            // Arrange
            var fixture = new Fixture();

            var testValue = fixture.Create<string>();

            // Act
            _testClass.PositionNumber = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.PositionNumber);
        }

        [Fact]
        public void CanSetAndGetPositionDescription()
        {
            // Arrange
            var fixture = new Fixture();

            var testValue = fixture.Create<string>();

            // Act
            _testClass.PositionDescription = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.PositionDescription);
        }

        [Fact]
        public void CanSetAndGetPostionArea()
        {
            // Arrange
            var fixture = new Fixture();

            var testValue = fixture.Create<string>();

            // Act
            _testClass.PostionArea = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.PostionArea);
        }

        [Fact]
        public void CanSetAndGetPostionType()
        {
            // Arrange
            var fixture = new Fixture();

            var testValue = fixture.Create<string>();

            // Act
            _testClass.PostionType = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.PostionType);
        }

        [Fact]
        public void CanSetAndGetPositionSalary()
        {
            // Arrange
            var fixture = new Fixture();

            var testValue = fixture.Create<decimal>();

            // Act
            _testClass.PositionSalary = testValue;

            // Assert
            Assert.Equal(testValue, _testClass.PositionSalary);
        }
    }
}