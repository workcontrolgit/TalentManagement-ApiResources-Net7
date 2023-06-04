namespace TalentManagementAPI.Application.Tests.Helpers
{
    using AutoFixture;
    using AutoFixture.AutoMoq;
    using FluentAssertions;
    using System.Reflection;
    using TalentManagementAPI.Application.Helpers;
    using Xunit;
    using T = System.String;

    public class DataShapeHelper_1Tests
    {
        private DataShapeHelper<T> _testClass;

        public DataShapeHelper_1Tests()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            _testClass = fixture.Create<DataShapeHelper<T>>();
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new DataShapeHelper<T>();

            // Assert
            instance.Should().NotBeNull();
        }

        [Fact]
        public void CanSetAndGetProperties()
        {
            // Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());

            var testValue = fixture.Create<PropertyInfo[]>();

            // Act
            _testClass.Properties = testValue;

            // Assert
            _testClass.Properties.Should().BeSameAs(testValue);
        }
    }
}