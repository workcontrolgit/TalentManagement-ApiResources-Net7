namespace TalentManagementAPI.Application.Tests.Parameters
{
    using AutoFixture;
    using AutoFixture.AutoMoq;
    using FluentAssertions;
    using TalentManagementAPI.Application.Parameters;
    using Xunit;

    public class SearchTests
    {
        private Search _testClass;

        public SearchTests()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            _testClass = fixture.Create<Search>();
        }

        [Fact]
        public void CanSetAndGetValue()
        {
            // Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());

            var testValue = fixture.Create<string>();

            // Act
            _testClass.Value = testValue;

            // Assert
            _testClass.Value.Should().Be(testValue);
        }

        [Fact]
        public void CanSetAndGetRegex()
        {
            // Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());

            var testValue = fixture.Create<bool>();

            // Act
            _testClass.Regex = testValue;

            // Assert
            _testClass.Regex.Should().Be(testValue);
        }
    }
}