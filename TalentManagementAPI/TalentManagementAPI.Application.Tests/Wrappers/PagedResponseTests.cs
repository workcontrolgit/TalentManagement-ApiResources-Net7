namespace TalentManagementAPI.Application.Tests.Wrappers
{
    using AutoFixture;
    using AutoFixture.AutoMoq;
    using FluentAssertions;
    using TalentManagementAPI.Application.Parameters;
    using TalentManagementAPI.Application.Wrappers;
    using Xunit;
    using T = System.String;

    public class PagedResponse_1Tests
    {
        private PagedResponse<T> _testClass;
        private T _data;
        private int _pageNumber;
        private int _pageSize;
        private RecordsCount _recordsCount;

        public PagedResponse_1Tests()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            _data = fixture.Create<T>();
            _pageNumber = fixture.Create<int>();
            _pageSize = fixture.Create<int>();
            _recordsCount = fixture.Create<RecordsCount>();
            _testClass = fixture.Create<PagedResponse<T>>();
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new PagedResponse<T>(_data, _pageNumber, _pageSize, _recordsCount);

            // Assert
            instance.Should().NotBeNull();
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

        [Fact]
        public void CanSetAndGetPageSize()
        {
            // Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());

            var testValue = fixture.Create<int>();

            // Act
            _testClass.PageSize = testValue;

            // Assert
            _testClass.PageSize.Should().Be(testValue);
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