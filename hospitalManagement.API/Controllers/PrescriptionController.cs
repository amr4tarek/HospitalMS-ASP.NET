using hospitalManagement.Application.Dtos;
using hospitalManagement.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace hospitalManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Doctor,Admin")]
    public class PrescriptionController : ControllerBase
    {
        private readonly IPrescriptionService _prescriptionService;

        public PrescriptionController(IPrescriptionService prescriptionService)
        {
            _prescriptionService = prescriptionService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPrescription(Guid id)
        {
            var result = await _prescriptionService.GetPrescriptionByIdAsync(id);
            if (!result.Success) return NotFound(result.Message);
            return Ok(result);
        }

        [HttpGet("medicalRecord/{medicalRecordId}")]
        public async Task<IActionResult> GetPrescriptionsByMedicalRecord(Guid medicalRecordId)
        {
            var result = await _prescriptionService.GetPrescriptionsByMedicalRecordIdAsync(medicalRecordId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePrescription([FromBody] PrescriptionDto prescriptionDto)
        {
            var result = await _prescriptionService.CreatePrescriptionAsync(prescriptionDto);
            if (!result.Success) return BadRequest(result.Message);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePrescription([FromBody] PrescriptionDto prescriptionDto)
        {
            var result = await _prescriptionService.UpdatePrescriptionAsync(prescriptionDto);
            if (!result.Success) return BadRequest(result.Message);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrescription(Guid id)
        {
            var result = await _prescriptionService.DeletePrescriptionAsync(id);
            if (!result.Success) return BadRequest(result.Message);
            return Ok(result);
        }
    }
}
