﻿using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TalentManagementAPI.Application.Interfaces;
using TalentManagementAPI.Application.Interfaces.Repositories;
using TalentManagementAPI.Application.Parameters;
using TalentManagementAPI.Application.Wrappers;
using TalentManagementAPI.Domain.Entities;

namespace TalentManagementAPI.Application.Features.Positions.Queries.GetPositions
{
    public partial class PagedPositionsQuery : IRequest<PagedDataTableResponse<IEnumerable<Entity>>>
    {
        //strong type input parameters
        public int Draw { get; set; } //page number
        public int Start { get; set; } //Paging first record indicator. This is the start point in the current data set (0 index based - i.e. 0 is the first record).
        public int Length { get; set; } //page size
        public IList<Order> Order { get; set; } //Order by
        public Search Search { get; set; } //search criteria
        public IList<Column> Columns { get; set; } //select fields
    }

    public class PagePositionQueryHandler : IRequestHandler<PagedPositionsQuery, PagedDataTableResponse<IEnumerable<Entity>>>
    {
        private readonly IPositionRepositoryAsync _positionRepository;
        private readonly IModelHelper _modelHelper;



        /// <summary>
        /// Constructor for PagePositionQueryHandler class.
        /// </summary>
        /// <param name="positionRepository">IPositionRepositoryAsync object.</param>
        /// <param name="mapper">IMapper object.</param>
        /// <param name="modelHelper">IModelHelper object.</param>
        /// <returns>
        /// PagePositionQueryHandler object.
        /// </returns>
        public PagePositionQueryHandler(IPositionRepositoryAsync positionRepository, IMapper mapper, IModelHelper modelHelper)
        {
            _positionRepository = positionRepository;
            _modelHelper = modelHelper;
        }



        /// <summary>
        /// Handles the specified PagedPositionsQuery request with the given CancellationToken.
        /// </summary>
        public async Task<PagedDataTableResponse<IEnumerable<Entity>>> Handle(PagedPositionsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = new GetPositionsQuery();

            // Draw map to PageNumber
            validFilter.PageNumber = (request.Start / request.Length) + 1;
            // Length map to PageSize
            validFilter.PageSize = request.Length;

            // Map order > OrderBy
            var colOrder = request.Order[0];
            switch (colOrder.Column)
            {
                case 0:
                    validFilter.OrderBy = colOrder.Dir == "asc" ? "PositionNumber" : "PositionNumber DESC";
                    break;

                case 1:
                    validFilter.OrderBy = colOrder.Dir == "asc" ? "PositionTitle" : "PositionTitle DESC";
                    break;

                case 2:
                    validFilter.OrderBy = colOrder.Dir == "asc" ? "PositionDescription" : "PositionDescription DESC";
                    break;
            }

            // Map Search > searchable columns
            if (!string.IsNullOrEmpty(request.Search.Value))
            {
                //limit to fields in view model
                validFilter.PositionNumber = request.Search.Value;
                validFilter.PositionTitle = request.Search.Value;
                validFilter.PositionDescription = request.Search.Value;
            }
            if (string.IsNullOrEmpty(validFilter.Fields))
            {
                //default fields from view model
                validFilter.Fields = _modelHelper.GetModelFields<GetPositionsViewModel>();
            }
            // query based on filter
            var entityPositions = await _positionRepository.GetPagedPositionReponseAsync(validFilter);
            var data = entityPositions.data;
            RecordsCount recordCount = entityPositions.recordsCount;

            // response wrapper
            return new PagedDataTableResponse<IEnumerable<Entity>>(data, request.Draw, recordCount);
        }
    }
}