using hospitalManagement.Application.Dtos.Users;
using hospitalManagement.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hospitalManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Patient,Admin")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatient(Guid id)
        {
            var result = await _patientService.GetPatientByIdAsync(id);
            if (!result.Success) return NotFound(result.Message);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPatients()
        {
            var result = await _patientService.GetAllPatientsAsync();
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePatient([FromBody] PatientDto patientDto)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            var existing = await _patientService.GetPatientByIdAsync(patientDto.Id);
            if (!existing.Success)
                return NotFound(existing.Message);
            if (User.IsInRole("Patient") && existing.Data.ApplicationUser.Id.ToString() != userId)
            {
                return Unauthorized("You are not authorized to update this patient's record.");
            }
            var result = await _patientService.UpdatePatientAsync(patientDto);
            if (!result.Success) return BadRequest(result.Message);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePatient(Guid id)
        {
            var result = await _patientService.DeletePatientAsync(id);
            if (!result.Success) return BadRequest(result.Message);
            return Ok(result);
        }
    }
}
