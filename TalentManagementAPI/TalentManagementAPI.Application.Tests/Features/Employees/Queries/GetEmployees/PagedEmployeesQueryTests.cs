namespace TalentManagementAPI.Application.Tests.Features.Employees.Queries.GetEmployees
{
    using AutoFixture;
    using AutoFixture.AutoMoq;
    using AutoMapper;
    using FluentAssertions;
    using Moq;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using TalentManagementAPI.Application.Features.Employees.Queries.GetEmployees;
    using TalentManagementAPI.Application.Interfaces;
    using TalentManagementAPI.Application.Interfaces.Repositories;
    using TalentManagementAPI.Application.Parameters;
    using Xunit;

    public partial class PagedEmployeesQueryTests
    {
        private PagedEmployeesQuery _testClass;

        public PagedEmployeesQueryTests()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            _testClass = fixture.Create<PagedEmployeesQuery>();
        }

        [Fact]
        public void CanSetAndGetDraw()
        {
            // Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());

            var testValue = fixture.Create<int>();

            // Act
            _testClass.Draw = testValue;

            // Assert
            _testClass.Draw.Should().Be(testValue);
        }

        [Fact]
        public void CanSetAndGetStart()
        {
            // Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());

            var testValue = fixture.Create<int>();

            // Act
            _testClass.Start = testValue;

            // Assert
            _testClass.Start.Should().Be(testValue);
        }

        [Fact]
        public void CanSetAndGetLength()
        {
            // Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());

            var testValue = fixture.Create<int>();

            // Act
            _testClass.Length = testValue;

            // Assert
            _testClass.Length.Should().Be(testValue);
        }

        [Fact]
        public void CanSetAndGetOrder()
        {
            // Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());

            var testValue = fixture.Create<IList<Order>>();

            // Act
            _testClass.Order = testValue;

            // Assert
            _testClass.Order.Should().BeSameAs(testValue);
        }

        [Fact]
        public void CanSetAndGetSearch()
        {
            // Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());

            var testValue = fixture.Create<Search>();

            // Act
            _testClass.Search = testValue;

            // Assert
            _testClass.Search.Should().BeSameAs(testValue);
        }

        [Fact]
        public void CanSetAndGetColumns()
        {
            // Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());

            var testValue = fixture.Create<IList<Column>>();

            // Act
            _testClass.Columns = testValue;

            // Assert
            _testClass.Columns.Should().BeSameAs(testValue);
        }
    }

    public class PageEmployeeQueryHandlerTests
    {
        private PageEmployeeQueryHandler _testClass;
        private Mock<IEmployeeRepositoryAsync> _employeeRepository;
        private Mock<IMapper> _mapper;
        private Mock<IModelHelper> _modelHelper;

        public PageEmployeeQueryHandlerTests()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            _employeeRepository = fixture.Freeze<Mock<IEmployeeRepositoryAsync>>();
            _mapper = fixture.Freeze<Mock<IMapper>>();
            _modelHelper = fixture.Freeze<Mock<IModelHelper>>();
            _testClass = fixture.Create<PageEmployeeQueryHandler>();
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new PageEmployeeQueryHandler(_employeeRepository.Object, _mapper.Object, _modelHelper.Object);

            // Assert
            instance.Should().NotBeNull();
        }



        [Fact]
        public async Task HandlePerformsMapping()
        {
            // Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            var request = fixture.Create<PagedEmployeesQuery>();
            var cancellationToken = fixture.Create<CancellationToken>();

            // Act
            var result = await _testClass.Handle(request, cancellationToken);

            // Assert
            result.Draw.Should().Be(request.Draw);
        }
    }
}