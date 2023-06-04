namespace TalentManagementAPI.Application.Tests.Wrappers
{
    using AutoFixture;
    using AutoFixture.AutoMoq;
    using FluentAssertions;
    using System.Collections.Generic;
    using TalentManagementAPI.Application.Wrappers;
    using Xunit;
    using T = System.String;

    public class Response_1Tests
    {
        private Response<T> _testClass;
        private T _data;
        private string _message;

        public Response_1Tests()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            _data = fixture.Create<T>();
            _message = fixture.Create<string>();
            _testClass = fixture.Create<Response<T>>();
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new Response<T>();

            // Assert
            instance.Should().NotBeNull();

            // Act
            instance = new Response<T>(_data, _message);

            // Assert
            instance.Should().NotBeNull();

            // Act
            instance = new Response<T>(_message);

            // Assert
            instance.Should().NotBeNull();
        }


        [Fact]
        public void CanSetAndGetSucceeded()
        {
            // Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());

            var testValue = fixture.Create<bool>();

            // Act
            _testClass.Succeeded = testValue;

            // Assert
            _testClass.Succeeded.Should().Be(testValue);
        }

        [Fact]
        public void CanSetAndGetMessage()
        {
            // Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());

            var testValue = fixture.Create<string>();

            // Act
            _testClass.Message = testValue;

            // Assert
            _testClass.Message.Should().Be(testValue);
        }

        [Fact]
        public void CanSetAndGetErrors()
        {
            // Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());

            var testValue = fixture.Create<List<string>>();

            // Act
            _testClass.Errors = testValue;

            // Assert
            _testClass.Errors.Should().BeSameAs(testValue);
        }

        [Fact]
        public void CanSetAndGetData()
        {
            // Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());

            var testValue = fixture.Create<T>();

            // Act
            _testClass.Data = testValue;

            // Assert
            _testClass.Data.Should().Be(testValue);
        }
    }
}