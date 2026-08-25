using AeroCore.Application.Comon.Pagination;
using AeroCore.Application.Comon.Response;
using AeroCore.Application.Dtos.AirlineDto;
using AeroCore.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using Serilog.Core;

namespace AeroCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirlineController : ControllerBase
    {
        private readonly IAirlineService airlineService;
        private readonly ILogger<AirlineController> _logger;
        public AirlineController(IAirlineService Airline, ILogger
            <AirlineController> Logger)
        {
            airlineService = Airline; 
            _logger = Logger;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var air = await airlineService.GetAllAsync();
            return Ok(ApiResponse<IEnumerable<ResponseAirlineDto>>.SuccessResponse(
                air, "Airport Fetched Successfully!"));
        }
        [HttpGet("paged")]
        public async Task<IActionResult> GetAirlines(int PageNumber = 1, int PageSize = 10)
        {
            var res = await airlineService.GetPagedAsync(PageNumber, PageSize);
            return Ok(
                ApiResponse<PagedResult<ResponseAirlineDto>>.SuccessResponse(res,
                "Airline fetched Successfully!"));
        }
        [HttpGet("Id")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var air = await airlineService.GetByIdAsync(id);
            if (air == null)
                return BadRequest("Airline is not Found!");
            return Ok(ApiResponse<ResponseAirlineDto>.SuccessResponse(air,
                "Airline fechted Successfully!"));
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(CreateAirlineDto dto)
        {
            _logger.LogInformation("Creating Airline");
            await airlineService.AddAsync(dto);
            _logger.LogInformation("Airline Created Successfully");
            return Ok("Airline Added Successfully!");
        }
        [HttpPut("Id")]
        public async Task<IActionResult> UpdateAsync(int id, UpdateAirDto dto)
        {
            await airlineService.UpdateAsync(id, dto);
            return Ok(ApiResponse<string?>.SuccessResponse(null,
                "Airline Updated Successfully!"));
        }
        [HttpDelete("Id")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await airlineService.DeleteAsync(id);
            return Ok(ApiResponse<string?>.SuccessResponse(null,
                "Airline Deleted Successfully"));
        }
    }
}
