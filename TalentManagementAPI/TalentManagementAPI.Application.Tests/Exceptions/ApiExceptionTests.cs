namespace TalentManagementAPI.Application.Tests.Exceptions
{
    using AutoFixture;
    using AutoFixture.AutoMoq;
    using FluentAssertions;
    using System;
    using TalentManagementAPI.Application.Exceptions;
    using Xunit;

    public class ApiExceptionTests
    {
        private ApiException _testClass;
        private string _message;
        private object[] _args;
        private Exception _innerException;

        public ApiExceptionTests()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            _message = fixture.Create<string>();
            _args = fixture.Create<object[]>();
            _innerException = fixture.Create<Exception>();
            _testClass = fixture.Create<ApiException>();
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new ApiException();

            // Assert
            instance.Should().NotBeNull();

            // Act
            instance = new ApiException(_message);

            // Assert
            instance.Should().NotBeNull();

            // Act
            instance = new ApiException(_message, _args);

            // Assert
            instance.Should().NotBeNull();

            // Act
            instance = new ApiException(_message, _innerException);

            // Assert
            instance.Should().NotBeNull();
        }

        [Fact]
        public void CannotConstructWithNullArgs()
        {
            // Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            FluentActions.Invoking(() => new ApiException(fixture.Create<string>(), default(object[]))).Should().Throw<ArgumentNullException>().WithParameterName("args");
        }



    }
}