using hospitalManagement.Application.Dtos.Auth;
using hospitalManagement.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace hospitalManagement.API.Controllers
{
     [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authService;
        
        public AuthenticationController(IAuthenticationService authService)
        {
            _authService = authService;
        }
        
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var result = await _authService.LoginAsync(loginDto);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result);
        }
        
        [HttpPost("register/doctor")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterDoctor([FromBody] RegisterDoctorDto registerDoctorDto)
        {
            var result = await _authService.RegisterDoctorAsync(registerDoctorDto);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result);
        }
        
        [HttpPost("register/patient")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterPatient([FromBody] RegisterPatientDto registerPatientDto)
        {
            var result = await _authService.RegisterPatientAsync(registerPatientDto);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result);
        }
        
        [HttpPost("register/staff")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterStaff([FromBody] RegisterStaffDto registerStaffDto)
        {
            var result = await _authService.RegisterStaffAsync(registerStaffDto);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result);
        }
    }
}
