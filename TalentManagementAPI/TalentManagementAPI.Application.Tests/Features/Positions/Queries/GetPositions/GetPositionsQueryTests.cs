namespace TalentManagementAPI.Application.Tests.Features.Positions.Queries.GetPositions
{
    using AutoFixture;
    using AutoFixture.AutoMoq;
    using AutoMapper;
    using FluentAssertions;
    using Moq;
    using TalentManagementAPI.Application.Features.Positions.Queries.GetPositions;
    using TalentManagementAPI.Application.Interfaces;
    using TalentManagementAPI.Application.Interfaces.Repositories;
    using Xunit;

    public class GetPositionsQueryTests
    {
        private GetPositionsQuery _testClass;

        public GetPositionsQueryTests()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            _testClass = fixture.Create<GetPositionsQuery>();
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
    }

    public class GetAllPositionsQueryHandlerTests
    {
        private GetAllPositionsQueryHandler _testClass;
        private Mock<IPositionRepositoryAsync> _positionRepository;
        private Mock<IMapper> _mapper;
        private Mock<IModelHelper> _modelHelper;

        public GetAllPositionsQueryHandlerTests()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            _positionRepository = fixture.Freeze<Mock<IPositionRepositoryAsync>>();
            _mapper = fixture.Freeze<Mock<IMapper>>();
            _modelHelper = fixture.Freeze<Mock<IModelHelper>>();
            _testClass = fixture.Create<GetAllPositionsQueryHandler>();
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new GetAllPositionsQueryHandler(_positionRepository.Object, _mapper.Object, _modelHelper.Object);

            // Assert
            instance.Should().NotBeNull();
        }

    }
}