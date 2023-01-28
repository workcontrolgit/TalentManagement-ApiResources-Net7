using System.Collections.Generic;
using TalentManagementAPI.Domain.Entities;

namespace TalentManagementAPI.Application.Interfaces
{
    public interface IMockService
    {
        List<Position> GetPositions(int rowCount);

        List<Employee> GetEmployees(int rowCount);

        List<Position> SeedPositions(int rowCount);
    }
}