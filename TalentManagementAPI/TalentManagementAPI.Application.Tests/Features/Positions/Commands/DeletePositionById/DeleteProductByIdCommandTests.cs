namespace TalentManagementAPI.Application.Tests.Features.Positions.Commands.DeletePositionById
{
    using AutoFixture;
    using AutoFixture.AutoMoq;
    using FluentAssertions;
    using System;
    using TalentManagementAPI.Application.Features.Positions.Commands.DeletePositionById;
    using Xunit;

    public class DeletePositionByIdCommandTests
    {
        private DeletePositionByIdCommand _testClass;

        public DeletePositionByIdCommandTests()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            _testClass = fixture.Create<DeletePositionByIdCommand>();
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
    }
}