using AeroCore.Application.Comon.Pagination;
using AeroCore.Application.Dtos.AirlineDto;
using AeroCore.Application.Interfaces;
using AeroCore.Application.Repositories;
using AeroCore.Domain.Model;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace AeroCore.Infrastructure.Service
{
    public class AirlineService : IAirlineService
    {
        private readonly IUnitofwork _unit;
        private readonly IMapper _mapper;
        private readonly ILogger<AirlineService> _logger;
        public AirlineService(IUnitofwork Unit,
            IMapper mapper, ILogger<AirlineService> logger)
        {
            _unit = Unit;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<IEnumerable<ResponseAirlineDto>> GetAllAsync()
        {
            var airline = await _unit.Airlines.GetAllAsync();
            return _mapper.Map<IEnumerable<ResponseAirlineDto>>(airline);
        }
        public async Task<PagedResult<ResponseAirlineDto>> GetPagedAsync(int pageNumber, int pageSize)
        {
            var airlines = await _unit.Airlines.GetPagedAsync(pageNumber, pageSize);

            return new PagedResult<ResponseAirlineDto>
            {
                Items = _mapper.Map<IEnumerable<ResponseAirlineDto>>(airlines.Items),
                TotalCount = airlines.TotalCount,
                PageNumber = airlines.PageNumber,
                PageSize = airlines.PageSize
            };
        }
        public async Task<ResponseAirlineDto> GetByIdAsync(int id)
        {
            var airline = await _unit.Airlines.GetbyIdAsync(id);
            if(airline == null)
            {
                throw new KeyNotFoundException("Airline not found");
            }
            return _mapper.Map<ResponseAirlineDto>(airline);
        }
        public async Task AddAsync(CreateAirlineDto dto)
        {
            _logger.LogInformation("Creating a new airline with name: {Name} and code: {Code}", dto.Name, dto.Code);
            var airline = _mapper.Map<Airline>(dto);
            await _unit.Airlines.CreateAsync(airline);  
            _logger.LogInformation("Successfully created airline with ID: {Id}", airline.Id);
            await _unit.SaveAsync();    
        }
        public async Task UpdateAsync(int id, UpdateAirDto dto)
        {
            var airline = await _unit.Airlines.GetbyIdAsync (id);
            if(airline == null)
            {
                throw new KeyNotFoundException("Airline is not found!");
            }
            _mapper.Map(dto, airline);
            await _unit.Airlines.UpdateAsync(id,airline);
            await _unit.SaveAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var airline = await _unit.Airlines.GetbyIdAsync(id);

            if (airline == null)
                throw new KeyNotFoundException("Airline not found.");

            await _unit.Airlines.DeleteAsync(id);
            await _unit.SaveAsync();
        }
    }
}
