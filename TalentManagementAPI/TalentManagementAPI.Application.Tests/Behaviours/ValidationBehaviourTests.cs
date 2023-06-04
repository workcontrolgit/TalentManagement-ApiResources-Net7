namespace TalentManagementAPI.Application.Tests.Behaviours
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using AutoFixture;
    using AutoFixture.AutoMoq;
    using FluentAssertions;
    using FluentValidation;
    using MediatR;
    using TalentManagementAPI.Application.Behaviours;
    using Xunit;
    using TRequest = System.String;
    using TResponse = System.String;


    public class ValidationBehavior_2Tests
    {
        private ValidationBehavior<TRequest, TResponse> _testClass;
        private IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior_2Tests()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            _validators = fixture.Create<IEnumerable<IValidator<TRequest>>>();
            _testClass = fixture.Create<ValidationBehavior<TRequest, TResponse>>();
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new ValidationBehavior<TRequest, TResponse>(_validators);

            // Assert
            instance.Should().NotBeNull();
        }

        [Fact]
        public void CannotConstructWithNullValidators()
        {
            FluentActions.Invoking(() => new ValidationBehavior<TRequest, TResponse>(default(IEnumerable<IValidator<TRequest>>))).Should().Throw<ArgumentNullException>().WithParameterName("validators");
        }

        [Fact]
        public async Task CanCallHandle()
        {
            // Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var request = fixture.Create<TRequest>();
            RequestHandlerDelegate<TResponse> next = () => fixture.Create<Task<TResponse>>();
            var cancellationToken = fixture.Create<CancellationToken>();

            // Act
            var result = await _testClass.Handle(request, next, cancellationToken);

            // Assert
            throw new NotImplementedException("Create or modify test");
        }

        [Fact]
        public async Task CannotCallHandleWithNullNext()
        {
            // Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            await FluentActions.Invoking(() => _testClass.Handle(fixture.Create<TRequest>(), default(RequestHandlerDelegate<TResponse>), fixture.Create<CancellationToken>())).Should().ThrowAsync<ArgumentNullException>().WithParameterName("next");
        }
    }
}