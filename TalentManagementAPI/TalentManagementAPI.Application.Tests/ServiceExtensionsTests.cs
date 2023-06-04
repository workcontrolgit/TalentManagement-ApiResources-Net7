namespace TalentManagementAPI.Application.Tests
{
    using FluentAssertions;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using TalentManagementAPI.Application;
    using Xunit;

    public static class ServiceExtensionsTests
    {

        [Fact]
        public static void CannotCallAddApplicationLayerWithNullServices()
        {
            FluentActions.Invoking(() => default(IServiceCollection).AddApplicationLayer()).Should().Throw<ArgumentNullException>().WithParameterName("services");
        }
    }
}