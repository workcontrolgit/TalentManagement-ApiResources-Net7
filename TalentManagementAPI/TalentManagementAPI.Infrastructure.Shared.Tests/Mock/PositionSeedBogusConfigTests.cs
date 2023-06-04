namespace TalentManagementAPI.Infrastructure.Shared.Tests.Mock
{
    using Moq.AutoMock;
    using TalentManagementAPI.Infrastructure.Shared.Mock;
    using Xunit;

    public class PositionSeedBogusConfigTests
    {
        private PositionSeedBogusConfig _testClass;

        public PositionSeedBogusConfigTests()
        {
            var mocker = new AutoMocker();
            _testClass = mocker.CreateInstance<PositionSeedBogusConfig>();
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new PositionSeedBogusConfig();

            // Assert
            Assert.NotNull(instance);
        }
    }
}