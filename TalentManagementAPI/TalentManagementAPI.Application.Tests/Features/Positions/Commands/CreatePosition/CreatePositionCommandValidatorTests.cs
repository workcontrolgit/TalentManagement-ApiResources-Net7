namespace TalentManagementAPI.Application.Tests.Features.Positions.Commands.CreatePosition
{
    using AutoFixture;
    using AutoFixture.AutoMoq;
    using FluentAssertions;
    using Moq;
    using TalentManagementAPI.Application.Features.Positions.Commands.CreatePosition;
    using TalentManagementAPI.Application.Interfaces.Repositories;
    using Xunit;

    public class CreatePositionCommandValidatorTests
    {
        private CreatePositionCommandValidator _testClass;
        private Mock<IPositionRepositoryAsync> _positionRepository;

        public CreatePositionCommandValidatorTests()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            _positionRepository = fixture.Freeze<Mock<IPositionRepositoryAsync>>();
            _testClass = fixture.Create<CreatePositionCommandValidator>();
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new CreatePositionCommandValidator(_positionRepository.Object);

            // Assert
            instance.Should().NotBeNull();
        }


    }
}