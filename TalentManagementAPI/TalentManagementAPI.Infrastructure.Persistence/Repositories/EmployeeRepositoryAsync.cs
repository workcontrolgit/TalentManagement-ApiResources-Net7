﻿using LinqKit;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using TalentManagementAPI.Application.Features.Employees.Queries.GetEmployees;
using TalentManagementAPI.Application.Interfaces;
using TalentManagementAPI.Application.Interfaces.Repositories;
using TalentManagementAPI.Application.Parameters;
using TalentManagementAPI.Domain.Entities;
using TalentManagementAPI.Infrastructure.Persistence.Contexts;
using TalentManagementAPI.Infrastructure.Persistence.Repository;

namespace TalentManagementAPI.Infrastructure.Persistence.Repositories
{
    public class EmployeeRepositoryAsync : GenericRepositoryAsync<Employee>, IEmployeeRepositoryAsync
    {
        private readonly IDataShapeHelper<Employee> _dataShaper;
        private readonly IMockService _mockData;



        /// <summary>
        /// Constructor for EmployeeRepositoryAsync class.
        /// </summary>
        /// <param name="dbContext">ApplicationDbContext object.</param>
        /// <param name="dataShaper">IDataShapeHelper object.</param>
        /// <param name="mockData">IMockService object.</param>
        /// <returns>
        /// 
        /// </returns>
        public EmployeeRepositoryAsync(ApplicationDbContext dbContext,
            IDataShapeHelper<Employee> dataShaper,
            IMockService mockData) : base(dbContext)
        {
            _dataShaper = dataShaper;
            _mockData = mockData;
        }



        /// <summary>
        /// Retrieves a paged list of employees based on the provided query parameters.
        /// </summary>
        /// <param name="requestParameters">The query parameters used to filter and page the data.</param>
        /// <returns>A tuple containing the paged list of employees and the total number of records.</returns>
        public async Task<(IEnumerable<Entity> data, RecordsCount recordsCount)> GetPagedEmployeeResponseAsync(GetEmployeesQuery requestParameters)
        {
            IQueryable<Employee> result;

            var employeeTitle = requestParameters.EmployeeTitle;
            var lastName = requestParameters.LastName;
            var firstName = requestParameters.FirstName;
            var email = requestParameters.Email;

            var pageNumber = requestParameters.PageNumber;
            var pageSize = requestParameters.PageSize;
            var orderBy = requestParameters.OrderBy;
            var fields = requestParameters.Fields;

            int recordsTotal, recordsFiltered;

            int seedCount = 1000;

            result = _mockData.GetEmployees(seedCount)
                .AsQueryable();

            // Count records total
            recordsTotal = result.Count();

            // filter data
            FilterByColumn(ref result, employeeTitle, lastName, firstName, email);

            // Count records after filter
            recordsFiltered = result.Count();

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

            //limit query fields
            if (!string.IsNullOrWhiteSpace(fields))
            {
                result = result.Select<Employee>("new(" + fields + ")");
            }
            // paging
            result = result
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);


            // retrieve data to list
            // var resultData = await result.ToListAsync();
            // Note: Bogus library does not support await for AsQueryable.
            // Workaround:  fake await with Task.Run and use regular ToList
            var resultData = await Task.Run(() => result.ToList());

            // shape data
            var shapeData = _dataShaper.ShapeData(resultData, fields);

            return (shapeData, recordsCount);
        }



        /// <summary>
        /// Filters an IQueryable of employees based on the provided parameters.
        /// </summary>
        /// <param name="employees">The IQueryable of employees to filter.</param>
        /// <param name="employeeTitle">The employee title to filter by.</param>
        /// <param name="lastName">The last name to filter by.</param>
        /// <param name="firstName">The first name to filter by.</param>
        /// <param name="email">The email to filter by.</param>
        private void FilterByColumn(ref IQueryable<Employee> employees, string employeeTitle, string lastName, string firstName, string email)
        {
            if (!employees.Any())
                return;

            if (string.IsNullOrEmpty(employeeTitle) && string.IsNullOrEmpty(lastName) && string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(email))
                return;

            var predicate = PredicateBuilder.New<Employee>();

            if (!string.IsNullOrEmpty(employeeTitle))
                predicate = predicate.Or(p => p.EmployeeTitle.ToLower().Contains(employeeTitle.ToLower().Trim()));

            if (!string.IsNullOrEmpty(lastName))
                predicate = predicate.Or(p => p.LastName.ToLower().Contains(lastName.ToLower().Trim()));

            if (!string.IsNullOrEmpty(firstName))
                predicate = predicate.Or(p => p.FirstName.ToLower().Contains(firstName.ToLower().Trim()));

            if (!string.IsNullOrEmpty(email))
                predicate = predicate.Or(p => p.Email.ToLower().Contains(email.ToLower().Trim()));


            employees = employees.Where(predicate);
        }
    }
}