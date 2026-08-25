using AeroCore.Application.Dtos.AirportDto;
using AeroCore.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AeroCore.Application.Interfaces
{
    public interface IAirportService
    {
        Task<IEnumerable<ResponseAirportDto>> GetAllAsync();
        Task<Airport?> GetAirportWithDetailAsync(int id);
        Task<ResponseAirportDto?> GetByIdAsync(int id);
        Task <ResponseAirportDto> AddAsync(CreateAirportDto dto);
        Task<bool> UpdateAsync(int id, UpdateAirportDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
