namespace TalentManagementAPI.Application.Tests.Parameters
{
    using AutoFixture;
    using AutoFixture.AutoMoq;
    using FluentAssertions;
    using TalentManagementAPI.Application.Parameters;
    using Xunit;

    public class RecordsCountTests
    {
        private RecordsCount _testClass;

        public RecordsCountTests()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            _testClass = fixture.Create<RecordsCount>();
        }

        [Fact]
        public void CanSetAndGetRecordsFiltered()
        {
            // Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());

            var testValue = fixture.Create<int>();

            // Act
            _testClass.RecordsFiltered = testValue;

            // Assert
            _testClass.RecordsFiltered.Should().Be(testValue);
        }

        [Fact]
        public void CanSetAndGetRecordsTotal()
        {
            // Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());

            var testValue = fixture.Create<int>();

            // Act
            _testClass.RecordsTotal = testValue;

            // Assert
            _testClass.RecordsTotal.Should().Be(testValue);
        }
    }
}