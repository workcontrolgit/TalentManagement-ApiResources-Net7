using LinqKit;
using Microsoft.EntityFrameworkCore;
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
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<Employee> _employee;
        private IDataShapeHelper<Employee> _dataShaper;
        private readonly IMockService _mockData;

        public EmployeeRepositoryAsync(ApplicationDbContext dbContext,
            IDataShapeHelper<Employee> dataShaper,
            IMockService mockData) : base(dbContext)
        {
            _dbContext = dbContext;
            _employee = dbContext.Set<Employee>();
            _dataShaper = dataShaper;
            _mockData = mockData;
        }

        public async Task<(IEnumerable<Entity> data, RecordsCount recordsCount)> GetPagedEmployeeReponseAsync(GetEmployeesQuery requestParameter)
        {
            IQueryable<Employee> result;

            var employeeNumber = requestParameter.EmployeeNumber;
            var employeeTitle = requestParameter.EmployeeTitle;
            var lastName = requestParameter.LastName;
            var firstName = requestParameter.FirstName;
            var email = requestParameter.Email;

            var pageNumber = requestParameter.PageNumber;
            var pageSize = requestParameter.PageSize;
            var orderBy = requestParameter.OrderBy;
            var fields = requestParameter.Fields;

            int recordsTotal, recordsFiltered;

            int seedCount = 1000;

            result = _mockData.GetEmployees(seedCount)
                .AsQueryable();

            // Count records total
            recordsTotal = result.Count();

            // filter data
            FilterByColumn(ref result, employeeNumber, employeeTitle, lastName, firstName, email);

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

        private void FilterByColumn(ref IQueryable<Employee> positions, string employeeNumber, string employeeTitle, string lastName, string firstName, string email)
        {
            if (!positions.Any())
                return;

            if (string.IsNullOrEmpty(employeeTitle) && string.IsNullOrEmpty(employeeNumber) && string.IsNullOrEmpty(lastName) && string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(email))
                return;

            var predicate = PredicateBuilder.New<Employee>();

            if (!string.IsNullOrEmpty(employeeNumber))
                predicate = predicate.And(p => p.EmployeeNumber.Contains(employeeNumber.Trim()));

            if (!string.IsNullOrEmpty(employeeTitle))
                predicate = predicate.And(p => p.EmployeeTitle.Contains(employeeTitle.Trim()));

            positions = positions.Where(predicate);
        }
    }
}