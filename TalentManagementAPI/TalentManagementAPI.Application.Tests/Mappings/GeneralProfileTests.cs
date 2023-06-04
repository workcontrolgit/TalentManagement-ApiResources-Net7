namespace TalentManagementAPI.Application.Tests.Mappings
{
    using AutoFixture;
    using AutoFixture.AutoMoq;
    using FluentAssertions;
    using TalentManagementAPI.Application.Mappings;
    using Xunit;

    public class GeneralProfileTests
    {
        private GeneralProfile _testClass;

        public GeneralProfileTests()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            _testClass = fixture.Create<GeneralProfile>();
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new GeneralProfile();

            // Assert
            instance.Should().NotBeNull();
        }
    }
}