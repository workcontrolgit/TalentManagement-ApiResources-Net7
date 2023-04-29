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

namespace TalentManagementAPI.Application.Features.Employees.Queries.GetEmployees
{
    public partial class PagedEmployeesQuery : IRequest<PagedDataTableResponse<IEnumerable<Entity>>>
    {
        //strong type input parameters
        public int Draw { get; set; } //page number
        public int Start { get; set; } //Paging first record indicator. This is the start point in the current data set (0 index based - i.e. 0 is the first record).
        public int Length { get; set; } //page size
        public IList<Order> Order { get; set; } //Order by
        public Search Search { get; set; } //search criteria
        public IList<Column> Columns { get; set; } //select fields
    }

    public class PageEmployeeQueryHandler : IRequestHandler<PagedEmployeesQuery, PagedDataTableResponse<IEnumerable<Entity>>>
    {
        private readonly IEmployeeRepositoryAsync _employeeRepository;
        private readonly IMapper _mapper;
        private readonly IModelHelper _modelHelper;



        /// <summary>
        /// Constructor for PageEmployeeQueryHandler class.
        /// </summary>
        /// <param name="employeeRepository">IEmployeeRepositoryAsync object.</param>
        /// <param name="mapper">IMapper object.</param>
        /// <param name="modelHelper">IModelHelper object.</param>
        /// <returns>
        /// PageEmployeeQueryHandler object.
        /// </returns>
        public PageEmployeeQueryHandler(IEmployeeRepositoryAsync employeeRepository, IMapper mapper, IModelHelper modelHelper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _modelHelper = modelHelper;
        }



        /// <summary>
        /// Handles the PagedEmployeesQuery request and returns a PagedDataTableResponse.
        /// </summary>
        /// <param name="request">The PagedEmployeesQuery request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A PagedDataTableResponse.</returns>
        public async Task<PagedDataTableResponse<IEnumerable<Entity>>> Handle(PagedEmployeesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = new GetEmployeesQuery();

            // Draw map to PageNumber
            validFilter.PageNumber = (request.Start / request.Length) + 1;
            // Length map to PageSize
            validFilter.PageSize = request.Length;

            // Map order > OrderBy
            var colOrder = request.Order[0];
            switch (colOrder.Column)
            {
                case 0:
                    validFilter.OrderBy = colOrder.Dir == "asc" ? "LastName" : "LastName DESC";
                    break;

                case 1:
                    validFilter.OrderBy = colOrder.Dir == "asc" ? "FirstName" : "FirstName DESC";
                    break;

                case 2:
                    validFilter.OrderBy = colOrder.Dir == "asc" ? "EmployeeTitle" : "EmployeeTitle DESC";
                    break;
                case 3:
                    validFilter.OrderBy = colOrder.Dir == "asc" ? "Email" : "Email DESC";
                    break;
            }

            // Map Search > searchable columns
            if (!string.IsNullOrEmpty(request.Search.Value))
            {
                //limit to fields in view model
                validFilter.LastName = request.Search.Value;
                validFilter.FirstName = request.Search.Value;
                validFilter.Email = request.Search.Value;
                validFilter.EmployeeNumber = request.Search.Value;
                validFilter.EmployeeTitle = request.Search.Value;
            }
            if (string.IsNullOrEmpty(validFilter.Fields))
            {
                //default fields from view model
                validFilter.Fields = _modelHelper.GetModelFields<GetEmployeesViewModel>();
            }
            // query based on filter
            var entityEmployees = await _employeeRepository.GetPagedEmployeeResponseAsync(validFilter);
            var data = entityEmployees.data;
            RecordsCount recordCount = entityEmployees.recordsCount;

            // response wrapper
            return new PagedDataTableResponse<IEnumerable<Entity>>(data, request.Draw, recordCount);
        }
    }
}