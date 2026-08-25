using AeroCore.Application.Comon.Pagination;
using AeroCore.Application.Dtos.AirlineDto;
using AeroCore.Application.Repositories;
using AeroCore.Domain.Model;
using AeroCore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AeroCore.Infrastructure.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(AppDbContext Context)
        {
            _context = Context; 
            _dbSet = Context.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<PagedResult<T>> GetPagedAsync(int PageNumber, int PageSize)
        {
            var query = _dbSet.AsQueryable();
            var totalcount = await query.CountAsync();
            var items = await query.Skip((PageNumber-1) *PageSize).Take(PageSize).ToListAsync();
            return new PagedResult<T>
            {
                Items = items,
                TotalCount = totalcount,
                PageNumber = PageNumber,
                PageSize = PageSize
            };
        }
        public async Task<T?> GetbyIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
        public async Task CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }
        public async Task UpdateAsync(int id, T entity)
        {
            var res = await _dbSet.FindAsync(id);    
            if(res != null)
            {
                _dbSet.Update(entity);
            }
        }
        public async Task DeleteAsync(int id)
        {
            var res = await _dbSet.FindAsync(id);
            if (res != null)
                _dbSet.Remove(res);
        }
    }
}
