namespace TalentManagementAPI.Infrastructure.Shared.Tests
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Moq;
    using System;
    using TalentManagementAPI.Infrastructure.Shared;
    using Xunit;

    public static class ServiceRegistrationTests
    {


        [Fact]
        public static void CannotCallAddSharedInfrastructureWithNullServices()
        {
            Assert.Throws<ArgumentNullException>(() => default(IServiceCollection).AddSharedInfrastructure(new Mock<IConfiguration>().Object));
        }

    }
}