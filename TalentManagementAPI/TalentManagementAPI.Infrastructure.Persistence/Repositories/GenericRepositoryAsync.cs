using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using TalentManagementAPI.Application.Interfaces;
using TalentManagementAPI.Infrastructure.Persistence.Contexts;

namespace TalentManagementAPI.Infrastructure.Persistence.Repository
{
    public class GenericRepositoryAsync<T> : IGenericRepositoryAsync<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;



        /// <summary>
        /// Constructor for GenericRepositoryAsync class.
        /// </summary>
        /// <param name="dbContext">ApplicationDbContext object.</param>
        /// <returns>
        /// No return value.
        /// </returns>
        public GenericRepositoryAsync(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }



        /// <summary>
        /// Retrieves an entity with the given Id from the database.
        /// </summary>
        /// <param name="id">The Id of the entity to be retrieved.</param>
        /// <returns>The entity with the given Id.</returns>
        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }



        /// <summary>
        /// Gets a paged response from the database.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <returns>A list of objects.</returns>
        public async Task<IEnumerable<T>> GetPagedReponseAsync(int pageNumber, int pageSize)
        {
            return await _dbContext
                .Set<T>()
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .AsNoTracking()
                .ToListAsync();
        }



        /// <summary>
        /// Retrieves a paged list of advanced responses from the database.
        /// </summary>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">The page size.</param>
        /// <param name="orderBy">The order by clause.</param>
        /// <param name="fields">The fields to select.</param>
        /// <returns>A list of advanced responses.</returns>
        public async Task<IEnumerable<T>> GetPagedAdvancedReponseAsync(int pageNumber, int pageSize, string orderBy, string fields)
        {
            return await _dbContext
                .Set<T>()
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select<T>("new(" + fields + ")")
                .OrderBy(orderBy)
                .AsNoTracking()
                .ToListAsync();
        }



        /// <summary>
        /// Adds an entity to the database asynchronously.
        /// </summary>
        /// <param name="entity">The entity to be added.</param>
        /// <returns>The entity that was added.</returns>
        public async Task<T> AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }



        /// <summary>
        /// Asynchronously bulk inserts a list of entities into the database.
        /// </summary>
        /// <param name="entity">The list of entities to be inserted.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task BulkInsertAsync(IList<T> entity)
        {
            await _dbContext.BulkInsertAsync(entity);
        }




        /// <summary>
        /// Updates an entity in the database.
        /// </summary>
        /// <param name="entity">The entity to be updated.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }



        /// <summary>
        /// Asynchronously deletes an entity from the database.
        /// </summary>
        /// <param name="entity">The entity to delete.</param>
        /// <returns>A task that represents the asynchronous delete operation.</returns>
        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }



        /// <summary>
        /// Retrieves a list of all entities from the database.
        /// </summary>
        /// <returns>A list of all entities.</returns>
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext
                 .Set<T>()
                 .ToListAsync();
        }
    }
}