namespace TalentManagementAPI.Application.Tests.Parameters
{
    using AutoFixture;
    using AutoFixture.AutoMoq;
    using FluentAssertions;
    using TalentManagementAPI.Application.Parameters;
    using Xunit;

    public class QueryParameterTests
    {
        private QueryParameter _testClass;

        public QueryParameterTests()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            _testClass = fixture.Create<QueryParameter>();
        }

        [Fact]
        public void CanSetAndGetOrderBy()
        {
            // Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());

            var testValue = fixture.Create<string>();

            // Act
            _testClass.OrderBy = testValue;

            // Assert
            _testClass.OrderBy.Should().Be(testValue);
        }

        [Fact]
        public void CanSetAndGetFields()
        {
            // Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());

            var testValue = fixture.Create<string>();

            // Act
            _testClass.Fields = testValue;

            // Assert
            _testClass.Fields.Should().Be(testValue);
        }
    }
}