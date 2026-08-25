using AeroCore.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroCore.Application.Repositories
{
    public interface IUnitofwork
    {
        IGenericRepository<Airline> Airlines { get; }
        IGenericRepository<Aircraft> Aircrafts {  get; }
        IGenericRepository<Airport> Airports { get; }
        IAirportRepository Airport { get; }
        IGenericRepository<Baggage> Baggages { get; }
        IGenericRepository<Flight> Flights { get; }
        Task<int> SaveAsync();
    }
}
