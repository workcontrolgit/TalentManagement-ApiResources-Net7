namespace TalentManagementAPI.WebApi.Tests.Models
{
    using AutoFixture;
    using AutoFixture.AutoMoq;
    using TalentManagementAPI.WebApi.Models;

    public class MetadataTests
    {
        private Metadata _testClass;

        public MetadataTests()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            _testClass = fixture.Create<Metadata>();
        }
    }
}