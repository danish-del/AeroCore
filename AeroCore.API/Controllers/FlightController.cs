using AeroCore.Application.Comon.Pagination;
using AeroCore.Application.Comon.Response;
using AeroCore.Application.Dtos.FlightDto;
using AeroCore.Application.Interfaces;
using AeroCore.Infrastructure.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AeroCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly IFlightService _flightService;
        public FlightController(IFlightService flightService)
        {
            _flightService = flightService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var res = await _flightService.GetAllAsync();
            return Ok(res);
        }
        [HttpGet("Paged")]
        public async Task<IActionResult> GetPagedAsync(int PageNumber = 1, int PageSize = 10)
        {
            var res = await _flightService.GetPagedAsync(PageNumber, PageSize);
            return Ok(ApiResponse<PagedResult<ResponseFlightDto>>.SuccessResponse(
                res, "Flights retrieved Successfully"));
        }
        [HttpPost]
        public async Task<IActionResult> GetbyIdAsync(int id)
        {
            var res = await _flightService.GetbyIdAsync(id);
            if(res == null)
            {
                throw new KeyNotFoundException("$ Flight with id {id} not found!");
            }
            return Ok(ApiResponse<ResponseFlightDto>.SuccessResponse(res,
                "Flight retrieved Successfully!"));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateFlightDto dto)
        {
            var res = await _flightService.UpdateAsync(id, dto);
            return Ok(ApiResponse<string?>.SuccessResponse(null, "Flight Updted Successfully!"
                ));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _flightService.DeleteAsync(id);
            return Ok("Deleted Successfully!");
        }
    }
}
