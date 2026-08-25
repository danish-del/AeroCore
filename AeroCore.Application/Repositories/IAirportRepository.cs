using AeroCore.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroCore.Application.Repositories
{
    public interface IAirportRepository : IGenericRepository<Airport>
    {
        Task<Airport?> GetAirportWithDetailAsync(int id);
    }
}
