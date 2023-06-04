namespace TalentManagementAPI.Application.Tests.Features.Employees.Queries.GetEmployees
{
    using AutoFixture;
    using AutoFixture.AutoMoq;
    using TalentManagementAPI.Application.Features.Employees.Queries.GetEmployees;

    public class GetEmployeesViewModelTests
    {
        private GetEmployeesViewModel _testClass;

        public GetEmployeesViewModelTests()
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            _testClass = fixture.Create<GetEmployeesViewModel>();
        }
    }
}