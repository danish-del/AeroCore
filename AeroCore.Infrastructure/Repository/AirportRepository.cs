using AeroCore.Application.Repositories;
using AeroCore.Domain.Model;
using AeroCore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace AeroCore.Infrastructure.Repository
{
    public class AirportRepository : GenericRepository<Airport> , IAirportRepository 
    {
        private readonly AppDbContext _context;
        public AirportRepository(AppDbContext Context) : base(Context)  
        { 
            this._context = Context;
        }
        public async Task<Airport?> GetAirportWithDetailAsync(int id)
        {
            return await _context.Airports
                .Include(a=>a.Airlines)
                .Include(a=>a.Aircraft) 
                .FirstOrDefaultAsync(a => a.Id == id);  
        }
    }
}
