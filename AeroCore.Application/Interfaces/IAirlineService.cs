using AeroCore.Application.Comon.Pagination;
using AeroCore.Application.Dtos.AirlineDto;
using AeroCore.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroCore.Application.Interfaces
{
    public interface IAirlineService
    {
        Task<IEnumerable<ResponseAirlineDto>> GetAllAsync();
        Task<PagedResult<ResponseAirlineDto>> GetPagedAsync(int PageNumber, int PageSize);
        Task<ResponseAirlineDto> GetByIdAsync(int id);
        Task AddAsync(CreateAirlineDto dto);
        Task UpdateAsync(int id, UpdateAirDto dto);
        Task DeleteAsync(int id);
    }
}
