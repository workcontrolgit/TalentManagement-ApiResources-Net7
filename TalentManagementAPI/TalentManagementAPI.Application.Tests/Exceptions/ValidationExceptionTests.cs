namespace TalentManagementAPI.Application.Tests.Exceptions
{
    using AutoFixture;
    using AutoFixture.AutoMoq;
    using FluentAssertions;
    using FluentValidation.Results;
    using System;
    using System.Collections.Generic;
    using TalentManagementAPI.Application.Exceptions;
    using Xunit;

    public class ValidationExceptionTests
    {
        private ValidationException _testClass;
        private IEnumerable<ValidationFailure> _failures;
        private string _message;
        private Exception _innerException;

        public ValidationExceptionTests()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            _failures = fixture.Create<IEnumerable<ValidationFailure>>();
            _message = fixture.Create<string>();
            _innerException = fixture.Create<Exception>();
            _testClass = fixture.Create<ValidationException>();
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new ValidationException();

            // Assert
            instance.Should().NotBeNull();

            // Act
            instance = new ValidationException(_failures);

            // Assert
            instance.Should().NotBeNull();

            // Act
            instance = new ValidationException(_message);

            // Assert
            instance.Should().NotBeNull();

            // Act
            instance = new ValidationException(_message, _innerException);

            // Assert
            instance.Should().NotBeNull();
        }

    }
}