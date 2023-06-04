namespace TalentManagementAPI.Application.Tests.Parameters
{
    using AutoFixture;
    using AutoFixture.AutoMoq;
    using FluentAssertions;
    using TalentManagementAPI.Application.Parameters;
    using Xunit;

    public class OrderTests
    {
        private Order _testClass;

        public OrderTests()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            _testClass = fixture.Create<Order>();
        }

        [Fact]
        public void CanSetAndGetColumn()
        {
            // Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());

            var testValue = fixture.Create<int>();

            // Act
            _testClass.Column = testValue;

            // Assert
            _testClass.Column.Should().Be(testValue);
        }

        [Fact]
        public void CanSetAndGetDir()
        {
            // Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());

            var testValue = fixture.Create<string>();

            // Act
            _testClass.Dir = testValue;

            // Assert
            _testClass.Dir.Should().Be(testValue);
        }
    }
}