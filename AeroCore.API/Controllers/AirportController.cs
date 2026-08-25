using AeroCore.Application.Comon.Response;
using AeroCore.Application.Dtos.AirportDto;
using AeroCore.Application.Interfaces;
using AeroCore.Infrastructure.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AeroCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportController : ControllerBase
    {
        private readonly IAirportService _airportService;
        public AirportController(IAirportService airportService)
        {
            _airportService = airportService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var res = await _airportService.GetAllAsync();
            return Ok(res);
        }
        [HttpGet("{id}/Details")]
        public async Task<IActionResult> GetAirportWithDetailAsync(int id)
        {
            var res  = await _airportService.GetAirportWithDetailAsync(id);
            if(res == null)
            {
                throw new KeyNotFoundException("Airport not found");
            }
            return Ok(res);
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(CreateAirportDto dto)
        {
           await _airportService.AddAsync(dto);
            return Ok("Airport added successfully");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id , UpdateAirportDto dto)
        {
            await _airportService.UpdateAsync(id, dto);
            return Ok(ApiResponse<string?>.SuccessResponse(null,
                "Airport Updated Sucessfully!"));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _airportService.DeleteAsync(id);
            return Ok(ApiResponse<string?>.SuccessResponse(null,
                "Airport Deleted Suceesfully")
                );
        }
    }
}
