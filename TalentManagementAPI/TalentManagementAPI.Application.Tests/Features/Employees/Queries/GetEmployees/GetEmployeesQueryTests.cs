namespace TalentManagementAPI.Application.Tests.Features.Employees.Queries.GetEmployees
{
    using AutoFixture;
    using AutoFixture.AutoMoq;
    using AutoMapper;
    using FluentAssertions;
    using Moq;
    using TalentManagementAPI.Application.Features.Employees.Queries.GetEmployees;
    using TalentManagementAPI.Application.Interfaces;
    using TalentManagementAPI.Application.Interfaces.Repositories;
    using Xunit;

    public class GetEmployeesQueryTests
    {
        private GetEmployeesQuery _testClass;

        public GetEmployeesQueryTests()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            _testClass = fixture.Create<GetEmployeesQuery>();
        }

        [Fact]
        public void CanSetAndGetEmployeeNumber()
        {
            // Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());

            var testValue = fixture.Create<string>();

            // Act
            _testClass.EmployeeNumber = testValue;

            // Assert
            _testClass.EmployeeNumber.Should().Be(testValue);
        }

        [Fact]
        public void CanSetAndGetEmployeeTitle()
        {
            // Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());

            var testValue = fixture.Create<string>();

            // Act
            _testClass.EmployeeTitle = testValue;

            // Assert
            _testClass.EmployeeTitle.Should().Be(testValue);
        }

        [Fact]
        public void CanSetAndGetLastName()
        {
            // Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());

            var testValue = fixture.Create<string>();

            // Act
            _testClass.LastName = testValue;

            // Assert
            _testClass.LastName.Should().Be(testValue);
        }

        [Fact]
        public void CanSetAndGetFirstName()
        {
            // Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());

            var testValue = fixture.Create<string>();

            // Act
            _testClass.FirstName = testValue;

            // Assert
            _testClass.FirstName.Should().Be(testValue);
        }

        [Fact]
        public void CanSetAndGetEmail()
        {
            // Arrange
            var fixture = new Fixture().Customize(new AutoMoqCustomization());

            var testValue = fixture.Create<string>();

            // Act
            _testClass.Email = testValue;

            // Assert
            _testClass.Email.Should().Be(testValue);
        }
    }

    public class GetAllEmployeesQueryHandlerTests
    {
        private GetAllEmployeesQueryHandler _testClass;
        private Mock<IEmployeeRepositoryAsync> _employeeRepository;
        private Mock<IMapper> _mapper;
        private Mock<IModelHelper> _modelHelper;

        public GetAllEmployeesQueryHandlerTests()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            _employeeRepository = fixture.Freeze<Mock<IEmployeeRepositoryAsync>>();
            _mapper = fixture.Freeze<Mock<IMapper>>();
            _modelHelper = fixture.Freeze<Mock<IModelHelper>>();
            _testClass = fixture.Create<GetAllEmployeesQueryHandler>();
        }

        [Fact]
        public void CanConstruct()
        {
            // Act
            var instance = new GetAllEmployeesQueryHandler(_employeeRepository.Object, _mapper.Object, _modelHelper.Object);

            // Assert
            instance.Should().NotBeNull();
        }
    }
}