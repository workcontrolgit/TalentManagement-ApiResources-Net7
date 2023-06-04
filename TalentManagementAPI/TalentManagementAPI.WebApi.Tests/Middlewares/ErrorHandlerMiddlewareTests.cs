namespace TalentManagementAPI.WebApi.Tests.Middlewares
{
    using AutoFixture;
    using AutoFixture.AutoMoq;
    using FluentAssertions;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;
    using Moq;
    using System.Threading.Tasks;
    using TalentManagementAPI.WebApi.Middlewares;
    using Xunit;

    public class ErrorHandlerMiddlewareTests
    {
        private ErrorHandlerMiddleware _testClass;
        private RequestDelegate _next;
        private Mock<ILogger<ErrorHandlerMiddleware>> _logger;

        public ErrorHandlerMiddlewareTests()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            _next = x => fixture.Create<Task>();
            _logger = fixture.Freeze<Mock<ILogger<ErrorHandlerMiddleware>>>();
            _testClass = fixture.Create<ErrorHandlerMiddleware>();
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new ErrorHandlerMiddleware(_next, _logger.Object);

            // Assert
            instance.Should().NotBeNull();
        }


    }
}