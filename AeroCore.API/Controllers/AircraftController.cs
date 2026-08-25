using AeroCore.Application.Comon.Pagination;
using AeroCore.Application.Comon.Response;
using AeroCore.Application.Dtos.AircraftDto;
using AeroCore.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AeroCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AircraftController : ControllerBase
    {
        private readonly IAircraftService _aircraftService;
        public AircraftController(IAircraftService aircraft)
        {
            this._aircraftService = aircraft;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var air = await _aircraftService.GetAllAsync();
            return Ok(ApiResponse<IEnumerable<ResponseAircraftDto>>.SuccessResponse(
               air, "Aircraft Fetched Successfully!"));
        }
        [HttpGet("Paged")]
        public async Task<IActionResult> GetPagedAsync(int PageNumber = 1, int PageSize = 10)
        {
            var air = await _aircraftService.GetPagedAsync(PageNumber, PageSize);
            return Ok(ApiResponse<PagedResult<ResponseAircraftDto>>.SuccessResponse(
                air, "Aircraft fetched Successfully!"));
        }
        [HttpGet("Id")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var air = await _aircraftService.GetbyIdAsync(id);
            if (air == null)
                return BadRequest("Id not found!");
            return Ok(ApiResponse<ResponseAircraftDto>.SuccessResponse(
                air, "Aircraft fetched Successfully!"));
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(CreateAircraftDto dto)
        {
            await _aircraftService.AddAsync(dto);
            return Ok(ApiResponse<CreateAircraftDto?>.SuccessResponse(null,
                "Aircraft Added Successfully!"));
        }
        [HttpPut("Id")]
        public async Task<IActionResult> UpdateAsync(int id, UpdateAircraftDto dto)
        {
            await _aircraftService.UpdateAsync(id, dto);
            return Ok(ApiResponse<string?>.SuccessResponse(null,
                "Aircraft Updated Succcessfully!"));
        }
        [HttpDelete("Id")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _aircraftService.DeleteAsync(id);
            return Ok(ApiResponse<string?>.SuccessResponse(null,
                "Aircraft deleted Successfully!"));
        }
    }
}
