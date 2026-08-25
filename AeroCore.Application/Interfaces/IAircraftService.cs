using AeroCore.Application.Comon.Pagination;
using AeroCore.Application.Dtos.AircraftDto;

namespace AeroCore.Application.Interfaces
{
    public interface IAircraftService
    {
        Task<IEnumerable<ResponseAircraftDto>> GetAllAsync();
        Task<PagedResult<ResponseAircraftDto>> GetPagedAsync(int pageNumber, int pageSize); 
        Task<ResponseAircraftDto> GetbyIdAsync(int id);
        Task AddAsync(CreateAircraftDto dto);
        Task UpdateAsync(int id, UpdateAircraftDto dto);
        Task DeleteAsync(int id);
    }
}
