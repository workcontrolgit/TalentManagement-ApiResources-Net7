namespace TalentManagementAPI.Application.Tests.Parameters
{
    using AutoFixture;
    using AutoFixture.AutoMoq;
    using FluentAssertions;
    using TalentManagementAPI.Application.Parameters;
    using Xunit;

    public class ColumnTests
    {
        private Column _testClass;

        public ColumnTests()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            _testClass = fixture.Create<Column>();
        }

        [Fact]
        public void CanSetAndGetData()
        {
            // Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());

            var testValue = fixture.Create<string>();

            // Act
            _testClass.Data = testValue;

            // Assert
            _testClass.Data.Should().Be(testValue);
        }

        [Fact]
        public void CanSetAndGetName()
        {
            // Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());

            var testValue = fixture.Create<string>();

            // Act
            _testClass.Name = testValue;

            // Assert
            _testClass.Name.Should().Be(testValue);
        }

        [Fact]
        public void CanSetAndGetSearchable()
        {
            // Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());

            var testValue = fixture.Create<bool>();

            // Act
            _testClass.Searchable = testValue;

            // Assert
            _testClass.Searchable.Should().Be(testValue);
        }

        [Fact]
        public void CanSetAndGetOrderable()
        {
            // Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());

            var testValue = fixture.Create<bool>();

            // Act
            _testClass.Orderable = testValue;

            // Assert
            _testClass.Orderable.Should().Be(testValue);
        }

        [Fact]
        public void CanSetAndGetSearch()
        {
            // Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());

            var testValue = fixture.Create<Search>();

            // Act
            _testClass.Search = testValue;

            // Assert
            _testClass.Search.Should().BeSameAs(testValue);
        }
    }
}