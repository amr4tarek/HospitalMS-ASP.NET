using hospitalManagement.Application.Dtos;
using hospitalManagement.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace hospitalManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] 
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppointment(Guid id)
        {
            var result = await _appointmentService.GetAppointmentByIdAsync(id);
            if (!result.Success) return NotFound(result.Message);
            return Ok(result);
        }

        [HttpGet("doctor/{doctorId}")]
        public async Task<IActionResult> GetAppointmentsByDoctor(Guid doctorId)
        {
            var result = await _appointmentService.GetAppointmentsByDoctorIdAsync(doctorId);
            return Ok(result);
        }

        [HttpGet("patient/{patientId}")]
        public async Task<IActionResult> GetAppointmentsByPatient(Guid patientId)
        {
            var result = await _appointmentService.GetAppointmentsByPatientIdAsync(patientId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppointment([FromBody] AppointmentDto appointmentDto)
        {
            var result = await _appointmentService.CreateAppointmentAsync(appointmentDto);
            if (!result.Success) return BadRequest(result.Message);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAppointment([FromBody] AppointmentDto appointmentDto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var existing = await _appointmentService.GetAppointmentByIdAsync(appointmentDto.Id);
            if (!existing.Success)
                return NotFound(existing.Message);
            if (User.IsInRole("Patient") &&
                (existing.Data.PatientId.ToString() != userId))
            {
                return Unauthorized("You are not authorized to update this appointment.");
            }
            var result = await _appointmentService.UpdateAppointmentAsync(appointmentDto);
            if (!result.Success) return BadRequest(result.Message);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(Guid id)
        {
            var result = await _appointmentService.DeleteAppointmentAsync(id);
            if (!result.Success) return BadRequest(result.Message);
            return Ok(result);
        }
    }
}
