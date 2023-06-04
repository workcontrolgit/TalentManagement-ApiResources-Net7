namespace TalentManagementAPI.Infrastructure.Shared.Tests.Mock
{
    using Moq.AutoMock;
    using TalentManagementAPI.Infrastructure.Shared.Mock;
    using Xunit;

    public class EmployeeBogusConfigTests
    {
        private EmployeeBogusConfig _testClass;

        public EmployeeBogusConfigTests()
        {
            var mocker = new AutoMocker();
            _testClass = mocker.CreateInstance<EmployeeBogusConfig>();
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new EmployeeBogusConfig();

            // Assert
            Assert.NotNull(instance);
        }
    }
}