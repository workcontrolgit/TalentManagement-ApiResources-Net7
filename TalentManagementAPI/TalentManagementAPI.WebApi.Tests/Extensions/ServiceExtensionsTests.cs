namespace TalentManagementAPI.WebApi.Tests.Extensions
{
    using AutoFixture;
    using AutoFixture.AutoMoq;
    using FluentAssertions;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using System;
    using TalentManagementAPI.WebApi.Extensions;
    using Xunit;

    public static class ServiceExtensionsTests
    {


        [Fact]
        public static void CannotCallAddSwaggerExtensionWithNullServices()
        {
            FluentActions.Invoking(() => default(IServiceCollection).AddSwaggerExtension()).Should().Throw<ArgumentNullException>().WithParameterName("services");
        }



        [Fact]
        public static void CannotCallAddControllersExtensionWithNullServices()
        {
            FluentActions.Invoking(() => default(IServiceCollection).AddControllersExtension()).Should().Throw<ArgumentNullException>().WithParameterName("services");
        }


        [Fact]
        public static void CannotCallAddCorsExtensionWithNullServices()
        {
            FluentActions.Invoking(() => default(IServiceCollection).AddCorsExtension()).Should().Throw<ArgumentNullException>().WithParameterName("services");
        }


        [Fact]
        public static void CannotCallAddVersionedApiExplorerExtensionWithNullServices()
        {
            FluentActions.Invoking(() => default(IServiceCollection).AddVersionedApiExplorerExtension()).Should().Throw<ArgumentNullException>().WithParameterName("services");
        }


        [Fact]
        public static void CannotCallAddApiVersioningExtensionWithNullServices()
        {
            FluentActions.Invoking(() => default(IServiceCollection).AddApiVersioningExtension()).Should().Throw<ArgumentNullException>().WithParameterName("services");
        }


        [Fact]
        public static void CannotCallAddJWTAuthenticationWithNullServices()
        {
            // Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            FluentActions.Invoking(() => default(IServiceCollection).AddJWTAuthentication(fixture.Create<IConfiguration>())).Should().Throw<ArgumentNullException>().WithParameterName("services");
        }


        [Fact]
        public static void CannotCallAddAuthorizationPoliciesWithNullServices()
        {
            // Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            FluentActions.Invoking(() => default(IServiceCollection).AddAuthorizationPolicies(fixture.Create<IConfiguration>())).Should().Throw<ArgumentNullException>().WithParameterName("services");
        }


    }
}