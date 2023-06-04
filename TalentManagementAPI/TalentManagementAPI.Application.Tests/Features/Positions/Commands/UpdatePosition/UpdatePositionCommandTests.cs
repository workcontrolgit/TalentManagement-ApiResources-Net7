namespace TalentManagementAPI.Application.Tests.Features.Positions.Commands.UpdatePosition
{
    using AutoFixture;
    using AutoFixture.AutoMoq;
    using FluentAssertions;
    using System;
    using TalentManagementAPI.Application.Features.Positions.Commands.UpdatePosition;
    using Xunit;

    public class UpdatePositionCommandTests
    {
        private UpdatePositionCommand _testClass;

        public UpdatePositionCommandTests()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            _testClass = fixture.Create<UpdatePositionCommand>();
        }

        [Fact]
        public void CanSetAndGetId()
        {
            // Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());

            var testValue = fixture.Create<Guid>();

            // Act
            _testClass.Id = testValue;

            // Assert
            _testClass.Id.Should().Be(testValue);
        }

        [Fact]
        public void CanSetAndGetPositionTitle()
        {
            // Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());

            var testValue = fixture.Create<string>();

            // Act
            _testClass.PositionTitle = testValue;

            // Assert
            _testClass.PositionTitle.Should().Be(testValue);
        }

        [Fact]
        public void CanSetAndGetPositionDescription()
        {
            // Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());

            var testValue = fixture.Create<string>();

            // Act
            _testClass.PositionDescription = testValue;

            // Assert
            _testClass.PositionDescription.Should().Be(testValue);
        }

        [Fact]
        public void CanSetAndGetPositionSalary()
        {
            // Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());

            var testValue = fixture.Create<decimal>();

            // Act
            _testClass.PositionSalary = testValue;

            // Assert
            _testClass.PositionSalary.Should().Be(testValue);
        }
    }
}