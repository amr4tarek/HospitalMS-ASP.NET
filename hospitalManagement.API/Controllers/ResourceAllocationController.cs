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
    public class ResourceAllocationController : ControllerBase
    {
        private readonly IResourceAllocationService _resourceAllocationService;

        public ResourceAllocationController(IResourceAllocationService resourceAllocationService)
        {
            _resourceAllocationService = resourceAllocationService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetResourceAllocation(Guid id)
        {
            var result = await _resourceAllocationService.GetResourceAllocationByIdAsync(id);
            if (!result.Success) return NotFound(result.Message);
            return Ok(result);
        }

        [HttpGet("appointment/{appointmentId}")]
        public async Task<IActionResult> GetResourceAllocationsByAppointment(Guid appointmentId)
        {
            var result = await _resourceAllocationService.GetResourceAllocationsByAppointmentIdAsync(appointmentId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateResourceAllocation([FromBody] ResourceAllocationDto resourceAllocationDto)
        {
            var result = await _resourceAllocationService.CreateResourceAllocationAsync(resourceAllocationDto);
            if (!result.Success) return BadRequest(result.Message);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateResourceAllocation([FromBody] ResourceAllocationDto resourceAllocationDto)
        {
            var result = await _resourceAllocationService.UpdateResourceAllocationAsync(resourceAllocationDto);
            if (!result.Success) return BadRequest(result.Message);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResourceAllocation(Guid id)
        {
            var result = await _resourceAllocationService.DeleteResourceAllocationAsync(id);
            if (!result.Success) return BadRequest(result.Message);
            return Ok(result);
        }
    }
}
