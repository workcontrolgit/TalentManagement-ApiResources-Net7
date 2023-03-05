using System.Collections.Generic;
using TalentManagementAPI.Domain.Entities;

namespace TalentManagementAPI.Application.Interfaces
{


    /// <summary>
    /// Interface for MockService.
    /// </summary>
    /// <returns>
    /// List of positions, employees, and seed positions.
    /// </returns>
    public interface IMockService
    {
        List<Position> GetPositions(int rowCount);

        List<Employee> GetEmployees(int rowCount);

        List<Position> SeedPositions(int rowCount);
    }
}