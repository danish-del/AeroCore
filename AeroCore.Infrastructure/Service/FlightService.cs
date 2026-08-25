using AeroCore.Application.Comon.Pagination;
using AeroCore.Application.Dtos.FlightDto;
using AeroCore.Application.Interfaces;
using AeroCore.Application.Repositories;
using AeroCore.Domain.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroCore.Infrastructure.Service
{
    public class FlightService : IFlightService
    {
        private readonly IUnitofwork _unit;
        private readonly IMapper _mapper;
        public FlightService(IUnitofwork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ResponseFlightDto>> GetAllAsync()
        {
            var flights = await _unit.Flights.GetAllAsync();
            return _mapper.Map<IEnumerable<ResponseFlightDto>>(flights);
        }
        public async Task<PagedResult<ResponseFlightDto>> GetPagedAsync(int PageNumber,int PageSize)
        {
            var flights = await _unit.Flights.GetPagedAsync(PageNumber, PageSize);
            return new PagedResult<ResponseFlightDto>
            {
                Items = _mapper.Map<IEnumerable<ResponseFlightDto>>(flights.Items),
                TotalCount = flights.TotalCount,
                PageNumber = flights.PageNumber,
                PageSize = flights.PageSize
            };
        }
        public async Task<ResponseFlightDto?> GetbyIdAsync(int id)
        {
            var flights = await _unit.Flights.GetbyIdAsync(id);
            return _mapper.Map<ResponseFlightDto?>(flights);   
        }
        public async Task AddAsync(CreateFlightDto dto)
        {
            var flights = _mapper.Map<Flight>(dto);
            await _unit.Flights.CreateAsync(flights);
            await _unit.SaveAsync();   
        }
        public async Task<bool> UpdateAsync(int id, UpdateFlightDto dto)
        {
            var flights = await _unit.Flights.GetbyIdAsync(id);
            if(flights == null)
            {
                throw new KeyNotFoundException("Id not found!");
            }
            _mapper.Map(dto, flights);
            await _unit.Flights.UpdateAsync(id,flights);
            await _unit.SaveAsync();
            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var flights = await _unit.Flights.GetbyIdAsync(id);
            if(flights == null)
            {
                throw new KeyNotFoundException("Id not found!");
            }
            await _unit.Flights.DeleteAsync(id);
            await _unit.SaveAsync();
            return true;
        }
    }
}
