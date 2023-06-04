namespace TalentManagementAPI.Infrastructure.Shared.Tests.Mock
{
    using Moq.AutoMock;
    using TalentManagementAPI.Infrastructure.Shared.Mock;
    using Xunit;

    public class PositionInsertBogusConfigTests
    {
        private PositionInsertBogusConfig _testClass;

        public PositionInsertBogusConfigTests()
        {
            var mocker = new AutoMocker();
            _testClass = mocker.CreateInstance<PositionInsertBogusConfig>();
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new PositionInsertBogusConfig();

            // Assert
            Assert.NotNull(instance);
        }
    }
}