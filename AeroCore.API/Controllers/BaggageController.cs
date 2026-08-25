using AeroCore.Application.Comon.Pagination;
using AeroCore.Application.Comon.Response;
using AeroCore.Application.Dtos.BaggageDto;
using AeroCore.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AeroCore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaggageController : ControllerBase
    {
        private readonly IBaggageService _baggageService;
        public BaggageController(IBaggageService baggageService)
        {
            _baggageService = baggageService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var res = await _baggageService.GetAllAsync();
            return Ok(ApiResponse<IEnumerable<ResponseBaggageDto>>.SuccessResponse
                (res,"Baggages Fetched Successfully!"));
        }
        [HttpGet("{Paged}/PagedDetails")]
        public async Task<IActionResult> GetPagedAsync(int PageNumber = 1, int PageSize =10)
        {
            var res = await _baggageService.GetPagedAsync(PageNumber, PageSize);
            return Ok(ApiResponse<PagedResult<ResponseBaggageDto>>.SuccessResponse(
                res, "Baggages Fetched Successfully!"));
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(CreateBaggageDto dto)
        {
            await _baggageService.AddAsync(dto);
            return Ok(ApiResponse<string?>.SuccessResponse
                (null, "Added Successfully!"));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, UpdateBaggageDto dto)
        {
            await _baggageService.UpdateAsync(id, dto);
            return Ok(ApiResponse<string?>.SuccessResponse
                (null, "Updated Successfully!"));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _baggageService.DeleteAsync(id);
            return Ok(ApiResponse<string?>.SuccessResponse(null,
                "Dleted Successfully!"));
        }
    }
}
