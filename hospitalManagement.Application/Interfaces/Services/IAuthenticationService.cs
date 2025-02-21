using hospitalManagement.Application.Dtos.Auth;
using hospitalManagement.Application.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalManagement.Application.Interfaces.Services
{
    public interface IAuthenticationService
    {
        Task<Result<string>> LoginAsync(LoginDto loginDto);
        Task<Result<string>> RegisterDoctorAsync(RegisterDoctorDto registerDoctorDto);
        Task<Result<string>> RegisterPatientAsync(RegisterPatientDto registerPatientDto);
        Task<Result<string>> RegisterStaffAsync(RegisterStaffDto registerStaffDto);
    }
}
