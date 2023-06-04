namespace TalentManagementAPI.Application.Tests.Parameters
{
    using AutoFixture;
    using AutoFixture.AutoMoq;
    using FluentAssertions;
    using TalentManagementAPI.Application.Parameters;
    using Xunit;

    public class PagingParameterTests
    {
        private PagingParameter _testClass;

        public PagingParameterTests()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            _testClass = fixture.Create<PagingParameter>();
        }

        [Fact]
        public void CanSetAndGetPageNumber()
        {
            // Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());

            var testValue = fixture.Create<int>();

            // Act
            _testClass.PageNumber = testValue;

            // Assert
            _testClass.PageNumber.Should().Be(testValue);
        }

    }
}