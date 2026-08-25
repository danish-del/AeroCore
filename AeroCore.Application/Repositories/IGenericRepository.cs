using AeroCore.Application.Comon.Pagination;
using AeroCore.Application.Dtos.AirlineDto;

namespace AeroCore.Application.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<PagedResult<T>> GetPagedAsync(int PageNumber, int PageSize);
        Task<T?> GetbyIdAsync(int id);
        Task CreateAsync(T entity);
        Task UpdateAsync(int id, T entity);
        Task DeleteAsync(int id);
    }
}
