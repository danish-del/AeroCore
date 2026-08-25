using AeroCore.Application.Comon.Pagination;
using AeroCore.Application.Dtos.AirlineDto;
using AeroCore.Application.Dtos.BaggageDto;
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
    public class BaggageService : IBaggageService
    {
        private readonly IUnitofwork _unit;
        private readonly IMapper _mapper;
        public BaggageService(IUnitofwork unit, IMapper mapper)
        {
             _unit = unit;
            _mapper = mapper;   
        }
        public async Task<IEnumerable<ResponseBaggageDto>> GetAllAsync()
        {
            var res = await _unit.Baggages.GetAllAsync();
            return _mapper.Map<IEnumerable<ResponseBaggageDto>>(res);
        }
        public async Task<PagedResult<ResponseBaggageDto>> GetPagedAsync(int pageNumber,
            int pageSize)
        {
            var res = await _unit.Baggages.GetPagedAsync(pageNumber, pageSize);

            return new PagedResult<ResponseBaggageDto>
            {
                Items = _mapper.Map<IEnumerable<ResponseBaggageDto>>(res.Items),
                TotalCount = res.TotalCount,
                PageNumber = res.PageNumber,
                PageSize = res.PageSize
            };
        }

        public async Task<ResponseBaggageDto?> GetByIdAsync(int id)
        {
            var res = await _unit.Baggages.GetbyIdAsync(id);
            if(res == null)
            {
                throw new KeyNotFoundException("id not found!");
            }
            return _mapper.Map<ResponseBaggageDto>(res);
        }
        public async Task<ResponseBaggageDto> AddAsync(CreateBaggageDto dto)
        {
            var res = _mapper.Map<Baggage>(dto);
            await _unit.Baggages.CreateAsync(res);
            await _unit.SaveAsync();
            return _mapper.Map<ResponseBaggageDto>(res);
        }
        public async Task<bool> UpdateAsync(int id, UpdateBaggageDto dto)
        {
            var res = await _unit.Baggages.GetbyIdAsync(id);
            if(res == null)
            {
                throw new KeyNotFoundException("Id not Found!");
            }
            _mapper.Map(res, dto);
            await _unit.Baggages.UpdateAsync(id,res);
            await _unit.SaveAsync();
            return true;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var res = await _unit.Baggages.GetbyIdAsync(id);
            if(res == null)
            {
                throw new KeyNotFoundException("Id not found!");
            }
            await _unit.Baggages.DeleteAsync(id);
            await _unit.SaveAsync();
            return false;
        }
    }
}
