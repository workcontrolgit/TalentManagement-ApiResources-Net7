using System.Collections.Generic;
using System.Threading.Tasks;
using TalentManagementAPI.Application.Features.Employees.Queries.GetEmployees;
using TalentManagementAPI.Application.Parameters;
using TalentManagementAPI.Domain.Entities;

namespace TalentManagementAPI.Application.Interfaces.Repositories
{
    public interface IEmployeeRepositoryAsync : IGenericRepositoryAsync<Employee>
    {
        Task<(IEnumerable<Entity> data, RecordsCount recordsCount)> GetPagedEmployeeReponseAsync(GetEmployeesQuery requestParameters);
    }
}