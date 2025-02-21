using hospitalManagement.Application.Dtos.Users;
using hospitalManagement.Application.Interfaces.Services;
using hospitalManagement.Domain.Models.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace hospitalManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Doctor,Admin")]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctor(Guid id)
        {
            var result = await _doctorService.GetDoctorByIdAsync(id);
            if (!result.Success) return NotFound(result.Message);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDoctors()
        {
            var result = await _doctorService.GetAllDoctorsAsync();
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDoctor([FromBody] DoctorDto doctorDto)
        {
            var userId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            var existing = await _doctorService.GetDoctorByIdAsync(doctorDto.Id);
            if (!existing.Success)
                return NotFound(existing.Message);
            if (User.IsInRole("Doctor") && existing.Data.ApplicationUser.Id.ToString() != userId)
            {
                return Unauthorized("You are not authorized to update this doctor's record.");
            }
            var result = await _doctorService.UpdateDoctorAsync(doctorDto);
            if (!result.Success) return BadRequest(result.Message);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(Guid id)
        {
            // similar checks here 
            var result = await _doctorService.DeleteDoctorAsync(id);
            if (!result.Success) return BadRequest(result.Message);
            return Ok(result);
        }
    }
}
