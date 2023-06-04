namespace TalentManagementAPI.Application.Tests.Features.Positions.Commands.CreatePosition
{
    using AutoFixture;
    using AutoFixture.AutoMoq;
    using FluentAssertions;
    using Moq;
    using TalentManagementAPI.Application.Features.Positions.Commands.CreatePosition;
    using TalentManagementAPI.Application.Interfaces.Repositories;
    using Xunit;

    public partial class InsertMockPositionCommandTests
    {
        private InsertMockPositionCommand _testClass;

        public InsertMockPositionCommandTests()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            _testClass = fixture.Create<InsertMockPositionCommand>();
        }

        [Fact]
        public void CanSetAndGetRowCount()
        {
            // Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());

            var testValue = fixture.Create<int>();

            // Act
            _testClass.RowCount = testValue;

            // Assert
            _testClass.RowCount.Should().Be(testValue);
        }
    }

    public class SeedPositionCommandHandlerTests
    {
        private SeedPositionCommandHandler _testClass;
        private Mock<IPositionRepositoryAsync> _positionRepository;

        public SeedPositionCommandHandlerTests()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            _positionRepository = fixture.Freeze<Mock<IPositionRepositoryAsync>>();
            _testClass = fixture.Create<SeedPositionCommandHandler>();
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new SeedPositionCommandHandler(_positionRepository.Object);

            // Assert
            instance.Should().NotBeNull();
        }

    }
}