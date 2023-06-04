namespace TalentManagementAPI.Application.Tests.Features.Positions.Commands.CreatePosition
{
    using AutoFixture;
    using AutoFixture.AutoMoq;
    using AutoMapper;
    using FluentAssertions;
    using Moq;
    using TalentManagementAPI.Application.Features.Positions.Commands.CreatePosition;
    using TalentManagementAPI.Application.Interfaces.Repositories;
    using Xunit;

    public partial class CreatePositionCommandTests
    {
        private CreatePositionCommand _testClass;

        public CreatePositionCommandTests()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            _testClass = fixture.Create<CreatePositionCommand>();
        }

        [Fact]
        public void CanSetAndGetPositionTitle()
        {
            // Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());

            var testValue = fixture.Create<string>();

            // Act
            _testClass.PositionTitle = testValue;

            // Assert
            _testClass.PositionTitle.Should().Be(testValue);
        }

        [Fact]
        public void CanSetAndGetPositionNumber()
        {
            // Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());

            var testValue = fixture.Create<string>();

            // Act
            _testClass.PositionNumber = testValue;

            // Assert
            _testClass.PositionNumber.Should().Be(testValue);
        }

        [Fact]
        public void CanSetAndGetPositionDescription()
        {
            // Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());

            var testValue = fixture.Create<string>();

            // Act
            _testClass.PositionDescription = testValue;

            // Assert
            _testClass.PositionDescription.Should().Be(testValue);
        }

        [Fact]
        public void CanSetAndGetPositionSalary()
        {
            // Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());

            var testValue = fixture.Create<decimal>();

            // Act
            _testClass.PositionSalary = testValue;

            // Assert
            _testClass.PositionSalary.Should().Be(testValue);
        }
    }

    public class CreatePositionCommandHandlerTests
    {
        private CreatePositionCommandHandler _testClass;
        private Mock<IPositionRepositoryAsync> _positionRepository;
        private Mock<IMapper> _mapper;

        public CreatePositionCommandHandlerTests()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            _positionRepository = fixture.Freeze<Mock<IPositionRepositoryAsync>>();
            _mapper = fixture.Freeze<Mock<IMapper>>();
            _testClass = fixture.Create<CreatePositionCommandHandler>();
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new CreatePositionCommandHandler(_positionRepository.Object, _mapper.Object);

            // Assert
            instance.Should().NotBeNull();
        }

    }
}