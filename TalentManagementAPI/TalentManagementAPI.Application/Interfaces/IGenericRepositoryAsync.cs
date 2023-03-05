using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TalentManagementAPI.Application.Interfaces
{


    /// <summary>
    /// Represents an interface for a generic repository with asynchronous methods.
    /// </summary>
    /// <typeparam name="T">The type of entity.</typeparam>
    /// <returns>
    /// An asynchronous repository for the specified entity type.
    /// </returns>
    public interface IGenericRepositoryAsync<T> where T : class
    {
        Task<T> GetByIdAsync(Guid id);

        Task<IEnumerable<T>> GetAllAsync();

        Task<IEnumerable<T>> GetPagedReponseAsync(int pageNumber, int pageSize);

        Task<IEnumerable<T>> GetPagedAdvancedReponseAsync(int pageNumber, int pageSize, string orderBy, string fields);

        Task<T> AddAsync(T entity);

        Task BulkInsertAsync(IList<T> entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);
    }
}