using System.Collections.Generic;
using TalentManagementAPI.Application.Interfaces;
using TalentManagementAPI.Domain.Entities;
using TalentManagementAPI.Infrastructure.Shared.Mock;

namespace TalentManagementAPI.Infrastructure.Shared.Services
{
    public class MockService : IMockService
    {
        public List<Position> GetPositions(int rowCount)
        {
            var faker = new PositionInsertBogusConfig();
            return faker.Generate(rowCount);
        }

        public List<Employee> GetEmployees(int rowCount)
        {
            var faker = new EmployeeBogusConfig();
            return faker.Generate(rowCount);
        }

        public List<Position> SeedPositions(int rowCount)
        {
            var faker = new PositionSeedBogusConfig();
            return faker.Generate(rowCount);
        }
    }
}