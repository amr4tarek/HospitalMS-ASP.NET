using AutoMapper;
using hospitalManagement.Application.Dtos.Auth;
using hospitalManagement.Application.Helpers;
using hospitalManagement.Application.Interfaces.Services;
using hospitalManagement.Application.Interfaces.UoW;
using hospitalManagement.Domain.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace hospitalManagement.Application.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AuthenticationService(
            UserManager<User> userManager,
            RoleManager<IdentityRole<Guid>> roleManager,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _configuration = configuration;
        }

        public async Task<Result<string>> LoginAsync(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null || !await _userManager.CheckPasswordAsync(user, loginDto.Password))
            {
                return Result<string>.FailureResult("Invalid credentials");
            }

            var token = await GenerateJwtToken(user);
            return Result<string>.SuccessResult(token, "Login successful");
        }

        public async Task<Result<string>> RegisterDoctorAsync(RegisterDoctorDto registerDoctorDto)
        {
            // Create ApplicationUser
            var user = new User
            {
                Email = registerDoctorDto.Email,
                UserName = registerDoctorDto.Email,
                FirstName = registerDoctorDto.FirstName,
                LastName = registerDoctorDto.LastName
            };

            var result = await _userManager.CreateAsync(user, registerDoctorDto.Password);
            if (!result.Succeeded)
            {
                var errors = string.Join(",", result.Errors.Select(e => e.Description));
                return Result<string>.FailureResult($"User registration failed: {errors}");
            }

            // Ensure the "Doctor" role exists
            if (!await _roleManager.RoleExistsAsync("Doctor"))
            {
                var roleResult = await _roleManager.CreateAsync(new IdentityRole<Guid>("Doctor"));
                if (!roleResult.Succeeded)
                {
                    return Result<string>.FailureResult("Failed to create Doctor role");
                }
            }
            await _userManager.AddToRoleAsync(user, "Doctor");

            // Create Doctor domain entity
            var doctor = new Doctor
            {
                ApplicationUserId = user.Id,
                Specialization = registerDoctorDto.Specialization,
                Qualifications = registerDoctorDto.Qualifications,
                YearsOfExperience = registerDoctorDto.YearsOfExperience,
                ClinicAddress = registerDoctorDto.ClinicAddress
            };

            await _unitOfWork.Doctors.AddAsync(doctor);
            await _unitOfWork.CommitAsync();

            return Result<string>.SuccessResult("Doctor registered successfully", "Doctor registered successfully");
        }

        public async Task<Result<string>> RegisterPatientAsync(RegisterPatientDto registerPatientDto)
        {
            // Create ApplicationUser
            var user = new User
            {
                Email = registerPatientDto.Email,
                UserName = registerPatientDto.Email,
                FirstName = registerPatientDto.FirstName,
                LastName = registerPatientDto.LastName
            };

            var result = await _userManager.CreateAsync(user, registerPatientDto.Password);
            if (!result.Succeeded)
            {
                var errors = string.Join(",", result.Errors.Select(e => e.Description));
                return Result<string>.FailureResult($"User registration failed: {errors}");
            }

            // Ensure the "Patient" role exists
            if (!await _roleManager.RoleExistsAsync("Patient"))
            {
                var roleResult = await _roleManager.CreateAsync(new IdentityRole<Guid>("Patient"));
                if (!roleResult.Succeeded)
                {
                    return Result<string>.FailureResult("Failed to create Patient role");
                }
            }
            await _userManager.AddToRoleAsync(user, "Patient");

            // Create Patient domain entity
            var patient = new Patient
            {
                ApplicationUserId = user.Id,
                DOB = registerPatientDto.DOB,
                Gender = registerPatientDto.Gender,
                Address = registerPatientDto.Address,
                ContactNumber = registerPatientDto.ContactNumber,
                InsuranceDetails = registerPatientDto.InsuranceDetails,
                EmergencyContact = registerPatientDto.EmergencyContact
            };

            await _unitOfWork.Patients.AddAsync(patient);
            await _unitOfWork.CommitAsync();

            return Result<string>.SuccessResult("Patient registered successfully", "Patient registered successfully");
        }

        public async Task<Result<string>> RegisterStaffAsync(RegisterStaffDto registerStaffDto)
        {
            // Create ApplicationUser
            var user = new User
            {
                Email = registerStaffDto.Email,
                UserName = registerStaffDto.Email,
                FirstName = registerStaffDto.FirstName,
                LastName = registerStaffDto.LastName
            };

            var result = await _userManager.CreateAsync(user, registerStaffDto.Password);
            if (!result.Succeeded)
            {
                var errors = string.Join(",", result.Errors.Select(e => e.Description));
                return Result<string>.FailureResult($"User registration failed: {errors}");
            }

            if (!await _roleManager.RoleExistsAsync(registerStaffDto.Role))
            {
                var roleResult = await _roleManager.CreateAsync(new IdentityRole<Guid>(registerStaffDto.Role));
                if (!roleResult.Succeeded)
                {
                    return Result<string>.FailureResult($"Failed to create role: {registerStaffDto.Role}");
                }
            }
            await _userManager.AddToRoleAsync(user, registerStaffDto.Role);


            return Result<string>.SuccessResult("Staff registered successfully", "Staff registered successfully");
        }

        private async Task<string> GenerateJwtToken(User user)
        {
            var userRoles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            claims.AddRange(userRoles.Select(role => new Claim(ClaimTypes.Role, role)));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Jwt:ExpireDays"])),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
