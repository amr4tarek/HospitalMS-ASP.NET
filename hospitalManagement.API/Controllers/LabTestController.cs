using hospitalManagement.Application.Dtos;
using hospitalManagement.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace hospitalManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Doctor,Patient,Admin")]
    public class LabTestController : ControllerBase
    {
        private readonly ILabTestService _labTestService;

        public LabTestController(ILabTestService labTestService)
        {
            _labTestService = labTestService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLabTest(Guid id)
        {
            var result = await _labTestService.GetLabTestByIdAsync(id);
            if (!result.Success) return NotFound(result.Message);
            return Ok(result);
        }

        [HttpGet("patient/{patientId}")]
        public async Task<IActionResult> GetLabTestsByPatient(Guid patientId)
        {
            var result = await _labTestService.GetLabTestsByPatientIdAsync(patientId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLabTest([FromBody] LabTestDto labTestDto)
        {
            var result = await _labTestService.CreateLabTestAsync(labTestDto);
            if (!result.Success) return BadRequest(result.Message);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLabTest([FromBody] LabTestDto labTestDto)
        {
            var result = await _labTestService.UpdateLabTestAsync(labTestDto);
            if (!result.Success) return BadRequest(result.Message);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLabTest(Guid id)
        {
            var result = await _labTestService.DeleteLabTestAsync(id);
            if (!result.Success) return BadRequest(result.Message);
            return Ok(result);
        }
    }
}
