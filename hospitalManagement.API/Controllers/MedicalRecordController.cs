using hospitalManagement.Application.Dtos;
using hospitalManagement.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace hospitalManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Doctor,Admin")]
    public class MedicalRecordController : ControllerBase
    {
        private readonly IMedicalRecordService _medicalRecordService;

        public MedicalRecordController(IMedicalRecordService medicalRecordService)
        {
            _medicalRecordService = medicalRecordService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMedicalRecord(Guid id)
        {
            var result = await _medicalRecordService.GetMedicalRecordByIdAsync(id);
            if (!result.Success) return NotFound(result.Message);
            return Ok(result);
        }

        [HttpGet("patient/{patientId}")]
        public async Task<IActionResult> GetMedicalRecordsByPatient(Guid patientId)
        {
            var result = await _medicalRecordService.GetMedicalRecordsByPatientIdAsync(patientId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMedicalRecord([FromBody] MedicalRecordDto medicalRecordDto)
        {
            var result = await _medicalRecordService.CreateMedicalRecordAsync(medicalRecordDto);
            if (!result.Success) return BadRequest(result.Message);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMedicalRecord([FromBody] MedicalRecordDto medicalRecordDto)
        {
            var result = await _medicalRecordService.UpdateMedicalRecordAsync(medicalRecordDto);
            if (!result.Success) return BadRequest(result.Message);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMedicalRecord(Guid id)
        {
            var result = await _medicalRecordService.DeleteMedicalRecordAsync(id);
            if (!result.Success) return BadRequest(result.Message);
            return Ok(result);
        }
    }
}
