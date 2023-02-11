using System.Collections.Generic;
using System.Threading.Tasks;
using TalentManagementAPI.Application.Features.Positions.Queries.GetPositions;
using TalentManagementAPI.Application.Parameters;
using TalentManagementAPI.Domain.Entities;

namespace TalentManagementAPI.Application.Interfaces.Repositories
{
    public interface IPositionRepositoryAsync : IGenericRepositoryAsync<Position>
    {
        Task<bool> IsUniquePositionNumberAsync(string positionNumber);

        Task SeedDataAsync(int rowCount);

        Task<(IEnumerable<Entity> data, RecordsCount recordsCount)> GetPagedPositionReponseAsync(GetPositionsQuery requestParameters);
    }
}