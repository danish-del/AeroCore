using AeroCore.Application.Dtos.AirlineDto;
using AeroCore.Application.Dtos.AirportDto;
using AeroCore.Application.Interfaces;
using AeroCore.Application.Repositories;
using AeroCore.Domain.Model;
using AeroCore.Infrastructure.Repository;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroCore.Infrastructure.Service
{
    public class AirportService : IAirportService
    {
        private readonly IUnitofwork _unitofwork;
        private readonly IMapper _mapper;
        public AirportService(IUnitofwork Unit, IMapper Mapper)
        {
            this._unitofwork = Unit;
            this._mapper = Mapper;
        }

        public async Task<IEnumerable<ResponseAirportDto>> GetAllAsync()
        {
            var airport = await _unitofwork.Airports.GetAllAsync();
            return _mapper.Map<IEnumerable<ResponseAirportDto>>(airport);
        }
        public async Task<Airport?> GetAirportWithDetailAsync(int id)
        {
            var res = await _unitofwork.Airport.GetAirportWithDetailAsync(id);
            return _mapper.Map<Airport>(res);
        }
       public async Task<ResponseAirportDto?> GetByIdAsync(int id)
        {
            var res = await _unitofwork.Airports.GetbyIdAsync(id);
            if(res == null)
            {
                throw new KeyNotFoundException("Id not found!");
            }
            return _mapper.Map<ResponseAirportDto>(res);
        }
        public async Task<ResponseAirportDto> AddAsync(CreateAirportDto dto)
        {
            var res = _mapper.Map<Airport>(dto);
            await _unitofwork.Airports.CreateAsync(res);
            await _unitofwork.SaveAsync();
            return _mapper.Map<ResponseAirportDto>(res);
        }
        public async Task<bool> UpdateAsync(int id, UpdateAirportDto dto)
        {
            var res = await _unitofwork.Airports.GetbyIdAsync(id);
            if(res == null)
            {
                throw new KeyNotFoundException("Id not found!");
            }
            _mapper.Map(res, dto);
            await _unitofwork.Airports.UpdateAsync(id,res);
            await _unitofwork.SaveAsync();
            return true;    
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var res = await _unitofwork.Airports.GetbyIdAsync(id);
            if(res == null)
            {
                throw new KeyNotFoundException();
            }
            await _unitofwork.Airports.DeleteAsync(id);
            await _unitofwork.SaveAsync();
            return false;   
        }
    }
}
