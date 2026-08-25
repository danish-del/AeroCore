using AeroCore.Application.Comon.Pagination;
using AeroCore.Application.Dtos.AircraftDto;
using AeroCore.Application.Interfaces;
using AeroCore.Application.Repositories;
using AeroCore.Domain.Model;
using AutoMapper;

namespace AeroCore.Infrastructure.Service
{
    public class AircraftService :  IAircraftService
    {
        private readonly IUnitofwork _unitofwork;
        private readonly IMapper _mapper;

        public AircraftService(IUnitofwork Unit, IMapper Mapper)
        {
            _unitofwork = Unit;
            _mapper = Mapper;
        }
        public async Task<IEnumerable<ResponseAircraftDto>> GetAllAsync()
        {
            var air = await _unitofwork.Aircrafts.GetAllAsync();
            return _mapper.Map<IEnumerable<ResponseAircraftDto>>(air);
        }
        public async Task<PagedResult<ResponseAircraftDto>> GetPagedAsync(int PageNumber, int PageSize)
        {
            var air = await _unitofwork.Aircrafts.GetPagedAsync(PageNumber, PageSize);
            return new PagedResult<ResponseAircraftDto>
            {
                Items = _mapper.Map<IEnumerable<ResponseAircraftDto>>(air.Items),
                TotalCount = air.TotalCount,
                PageNumber = PageNumber,
                PageSize = PageSize
            };
        }
        public async Task<ResponseAircraftDto> GetbyIdAsync(int id) 
        {
            var air = await _unitofwork.Aircrafts.GetbyIdAsync(id);
            if (air == null)
            {
                throw new Exception("Aircraf not found!");
            }
            return _mapper.Map<ResponseAircraftDto>(air);
        }
        public async Task AddAsync(CreateAircraftDto dto)
        {
            var air = _mapper.Map<Aircraft>(dto);
            await _unitofwork.Aircrafts.CreateAsync(air);
            await _unitofwork.SaveAsync();
        }
        public async Task UpdateAsync(int id,UpdateAircraftDto dto)
        {
            var air = await _unitofwork.Aircrafts.GetbyIdAsync(id);
            if(air == null)
            {
                throw new Exception("Id not found!");
            }
            _mapper.Map(dto, air);
            await _unitofwork.Aircrafts.UpdateAsync(id, air);
            await _unitofwork.SaveAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var air = await _unitofwork.Aircrafts.GetbyIdAsync(id);
            if(air == null)
            {
                throw new Exception("Id not found");
            }
            await _unitofwork.Aircrafts.DeleteAsync(id);
            await _unitofwork.SaveAsync();
        }
    }
}
