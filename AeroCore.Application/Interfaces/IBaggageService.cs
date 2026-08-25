using AeroCore.Application.Comon.Pagination;
using AeroCore.Application.Dtos.BaggageDto;

namespace AeroCore.Application.Interfaces
{
    public interface IBaggageService
    {
        Task<IEnumerable<ResponseBaggageDto>> GetAllAsync();
        Task<PagedResult<ResponseBaggageDto>> GetPagedAsync(int PageNumber, int PageSize);
        Task<ResponseBaggageDto?> GetByIdAsync(int id);
        Task<ResponseBaggageDto> AddAsync(CreateBaggageDto dto);
        Task<bool> UpdateAsync(int id, UpdateBaggageDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
