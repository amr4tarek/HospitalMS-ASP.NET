using hospitalManagement.Application.Dtos.Auth;
using hospitalManagement.Application.Dtos.Users;
using hospitalManagement.Application.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalManagement.Application.Interfaces.Services
{
    public interface IDoctorService
    {
        Task<Result<DoctorDto>> GetDoctorByIdAsync(Guid id);
        Task<Result<IEnumerable<DoctorDto>>> GetAllDoctorsAsync();
        Task<Result<DoctorDto>> CreateDoctorAsync(RegisterDoctorDto registerDoctorDto);
        Task<Result<DoctorDto>> UpdateDoctorAsync(DoctorDto doctorDto);
        Task<Result<bool>> DeleteDoctorAsync(Guid id);
    }
}
