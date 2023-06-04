namespace TalentManagementAPI.Application.Tests.Features.Positions.Queries.GetPositionById
{
    using AutoFixture;
    using AutoFixture.AutoMoq;
    using FluentAssertions;
    using System;
    using TalentManagementAPI.Application.Features.Positions.Queries.GetPositionById;
    using Xunit;

    public class GetPositionByIdQueryTests
    {
        private GetPositionByIdQuery _testClass;

        public GetPositionByIdQueryTests()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            _testClass = fixture.Create<GetPositionByIdQuery>();
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