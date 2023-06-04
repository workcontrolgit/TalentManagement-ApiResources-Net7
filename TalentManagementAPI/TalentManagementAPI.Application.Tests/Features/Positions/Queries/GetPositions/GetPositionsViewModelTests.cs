namespace TalentManagementAPI.Application.Tests.Features.Positions.Queries.GetPositions
{
    using AutoFixture;
    using AutoFixture.AutoMoq;
    using FluentAssertions;
    using System;
    using TalentManagementAPI.Application.Features.Positions.Queries.GetPositions;
    using Xunit;

    public class GetPositionsViewModelTests
    {
        private GetPositionsViewModel _testClass;

        public GetPositionsViewModelTests()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            _testClass = fixture.Create<GetPositionsViewModel>();
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
        public void CanSetAndGetPositionNumber()
        {
            // Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());

            var testValue = fixture.Create<string>();

            // Act
            _testClass.PositionNumber = testValue;

            // Assert
            _testClass.PositionNumber.Should().Be(testValue);
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