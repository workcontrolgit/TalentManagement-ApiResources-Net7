namespace TalentManagementAPI.Application.Tests.Wrappers
{
    using AutoFixture;
    using AutoFixture.AutoMoq;
    using FluentAssertions;
    using TalentManagementAPI.Application.Parameters;
    using TalentManagementAPI.Application.Wrappers;
    using Xunit;
    using T = System.String;

    public class PagedDataTableResponse_1Tests
    {
        private PagedDataTableResponse<T> _testClass;
        private T _data;
        private int _pageNumber;
        private RecordsCount _recordsCount;

        public PagedDataTableResponse_1Tests()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            _data = fixture.Create<T>();
            _pageNumber = fixture.Create<int>();
            _recordsCount = fixture.Create<RecordsCount>();
            _testClass = fixture.Create<PagedDataTableResponse<T>>();
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new PagedDataTableResponse<T>(_data, _pageNumber, _recordsCount);

            // Assert
            instance.Should().NotBeNull();
        }


        [Fact]
        public void CanSetAndGetDraw()
        {
            // Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());

            var testValue = fixture.Create<int>();

            // Act
            _testClass.Draw = testValue;

            // Assert
            _testClass.Draw.Should().Be(testValue);
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