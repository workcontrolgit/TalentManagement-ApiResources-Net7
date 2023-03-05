using LinqKit;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using TalentManagementAPI.Application.Features.Positions.Queries.GetPositions;
using TalentManagementAPI.Application.Interfaces;
using TalentManagementAPI.Application.Interfaces.Repositories;
using TalentManagementAPI.Application.Parameters;
using TalentManagementAPI.Domain.Entities;
using TalentManagementAPI.Infrastructure.Persistence.Contexts;
using TalentManagementAPI.Infrastructure.Persistence.Repository;

namespace TalentManagementAPI.Infrastructure.Persistence.Repositories
{
    public class PositionRepositoryAsync : GenericRepositoryAsync<Position>, IPositionRepositoryAsync
    {
        private readonly DbSet<Position> _positions;
        private readonly IDataShapeHelper<Position> _dataShaper;
        private readonly IMockService _mockData;



        /// <summary>
        /// Constructor for PositionRepositoryAsync class. 
        /// </summary>
        /// <param name="dbContext">ApplicationDbContext object.</param>
        /// <param name="dataShaper">IDataShapeHelper object.</param>
        /// <param name="mockData">IMockService object.</param>
        /// <returns>
        /// PositionRepositoryAsync object.
        /// </returns>
        public PositionRepositoryAsync(ApplicationDbContext dbContext,
            IDataShapeHelper<Position> dataShaper, IMockService mockData) : base(dbContext)
        {
            _positions = dbContext.Set<Position>();
            _dataShaper = dataShaper;
            _mockData = mockData;
        }



        /// <summary>
        /// Checks if the given position number is unique.
        /// </summary>
        /// <param name="positionNumber">The position number to check.</param>
        /// <returns>A boolean indicating if the position number is unique.</returns>
        public async Task<bool> IsUniquePositionNumberAsync(string positionNumber)
        {
            return await _positions
                .AllAsync(p => p.PositionNumber != positionNumber);
        }



        /// <summary>
        /// Seeds the data asynchronously.
        /// </summary>
        /// <param name="rowCount">The row count.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task SeedDataAsync(int rowCount)
        {
            await this.BulkInsertAsync(_mockData.GetPositions(rowCount));
        }



        /// <summary>
        /// Retrieves a paged response of positions based on the given query parameters.
        /// </summary>
        /// <param name="requestParameters">The query parameters used to filter and page the response.</param>
        /// <returns>A tuple containing the paged response of positions and the total number of records.</returns>
        public async Task<(IEnumerable<Entity> data, RecordsCount recordsCount)> GetPagedPositionReponseAsync(GetPositionsQuery requestParameters)
        {
            var positionNumber = requestParameters.PositionNumber;
            var positionTitle = requestParameters.PositionTitle;
            var positionDescription = requestParameters.PositionDescription;

            var pageNumber = requestParameters.PageNumber;
            var pageSize = requestParameters.PageSize;
            var orderBy = requestParameters.OrderBy;
            var fields = requestParameters.Fields;

            int recordsTotal, recordsFiltered;

            // Setup IQueryable
            var result = _positions
                .AsNoTracking()
                .AsExpandable();

            // Count records total
            recordsTotal = await result.CountAsync();

            // filter data
            FilterByColumn(ref result, positionNumber, positionTitle, positionDescription);

            // Count records after filter
            recordsFiltered = await result.CountAsync();

            //set Record counts
            var recordsCount = new RecordsCount
            {
                RecordsFiltered = recordsFiltered,
                RecordsTotal = recordsTotal
            };

            // set order by
            if (!string.IsNullOrWhiteSpace(orderBy))
            {
                result = result.OrderBy(orderBy);
            }

            // select columns
            if (!string.IsNullOrWhiteSpace(fields))
            {
                result = result.Select<Position>("new(" + fields + ")");
            }
            // paging
            result = result
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            // retrieve data to list
            var resultData = await result.ToListAsync();
            // shape data
            var shapeData = _dataShaper.ShapeData(resultData, fields);

            return (shapeData, recordsCount);
        }



        /// <summary>
        /// Filters a given IQueryable by position number, title, and description.
        /// </summary>
        private void FilterByColumn(ref IQueryable<Position> positions, string positionNumber, string positionTitle, string positionDescription)
        {
            if (!positions.Any())
                return;

            if (string.IsNullOrEmpty(positionTitle) && string.IsNullOrEmpty(positionNumber) && string.IsNullOrEmpty(positionDescription))
                return;

            var predicate = PredicateBuilder.New<Position>();

            if (!string.IsNullOrEmpty(positionNumber))
                predicate = predicate.Or(p => p.PositionNumber.ToLower().Contains(positionNumber.ToLower().Trim()));

            if (!string.IsNullOrEmpty(positionTitle))
                predicate = predicate.Or(p => p.PositionTitle.ToLower().Contains(positionTitle.ToLower().Trim()));

            if (!string.IsNullOrEmpty(positionDescription))
                predicate = predicate.Or(p => p.PositionDescription.ToLower().Contains(positionDescription.ToLower().Trim()));


            positions = positions.Where(predicate);
        }
    }
}