using AeroCore.Application.Repositories;
using AeroCore.Domain.Model;
using AeroCore.Infrastructure.Data;

namespace AeroCore.Infrastructure.Repository
{
    public class Unitofwork : IUnitofwork
    {
        private readonly AppDbContext _context;
        public IGenericRepository<Airline> Airlines { get; }
        public IGenericRepository<Aircraft> Aircrafts { get; }
        public IGenericRepository<Airport> Airports { get; }    
        public IAirportRepository Airport { get; }
        public IGenericRepository<Baggage> Baggages { get; }  
        public IGenericRepository<Flight> Flights { get; }

        public Unitofwork(AppDbContext Context)
        {
            _context = Context;
            Airlines = new GenericRepository<Airline>(_context);
            Aircrafts = new GenericRepository<Aircraft>(_context);
            Airports = new GenericRepository<Airport>(_context);    
            Airport = new AirportRepository(_context);
            Baggages = new GenericRepository<Baggage>(_context);
            Flights = new GenericRepository<Flight>(_context);  
        }
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();   
        }
    }
}
