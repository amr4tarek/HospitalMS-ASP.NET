using hospitalManagement.Application.Dtos;
using hospitalManagement.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hospitalManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,Staff")]
    public class StaffScheduleController : ControllerBase
    {
        private readonly IStaffScheduleService _staffScheduleService;

        public StaffScheduleController(IStaffScheduleService staffScheduleService)
        {
            _staffScheduleService = staffScheduleService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStaffSchedule(Guid id)
        {
            var result = await _staffScheduleService.GetStaffScheduleByIdAsync(id);
            if (!result.Success) return NotFound(result.Message);
            return Ok(result);
        }

        [HttpGet("staff/{staffId}")]
        public async Task<IActionResult> GetSchedulesByStaff(Guid staffId)
        {
            var result = await _staffScheduleService.GetSchedulesByStaffIdAsync(staffId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStaffSchedule([FromBody] StaffScheduleDto staffScheduleDto)
        {
            var result = await _staffScheduleService.CreateStaffScheduleAsync(staffScheduleDto);
            if (!result.Success) return BadRequest(result.Message);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStaffSchedule([FromBody] StaffScheduleDto staffScheduleDto)
        {
            var result = await _staffScheduleService.UpdateStaffScheduleAsync(staffScheduleDto);
            if (!result.Success) return BadRequest(result.Message);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaffSchedule(Guid id)
        {
            var result = await _staffScheduleService.DeleteStaffScheduleAsync(id);
            if (!result.Success) return BadRequest(result.Message);
            return Ok(result);
        }
    }
}
