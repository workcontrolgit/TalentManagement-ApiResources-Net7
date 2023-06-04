namespace TalentManagementAPI.WebApi.Tests.Extensions
{
    using AutoFixture;
    using AutoFixture.AutoMoq;
    using TalentManagementAPI.WebApi.Extensions;

    public class AuthorizationConstsTests
    {
        private AuthorizationConsts _testClass;

        public AuthorizationConstsTests()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            _testClass = fixture.Create<AuthorizationConsts>();
        }
    }
}