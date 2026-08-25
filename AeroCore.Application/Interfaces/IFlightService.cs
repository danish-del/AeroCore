using AeroCore.Application.Comon.Pagination;
using AeroCore.Application.Dtos.FlightDto;

namespace AeroCore.Application.Interfaces
{
    public interface IFlightService
    {
        Task<IEnumerable<ResponseFlightDto>> GetAllAsync();
        Task<PagedResult<ResponseFlightDto>> GetPagedAsync(int PageNumber, int PageSize);
        Task<ResponseFlightDto?> GetbyIdAsync(int id);
        Task<bool> UpdateAsync(int id, UpdateFlightDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
