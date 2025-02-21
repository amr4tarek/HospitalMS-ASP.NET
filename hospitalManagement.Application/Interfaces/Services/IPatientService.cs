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
    public interface IPatientService
    {
        Task<Result<PatientDto>> GetPatientByIdAsync(Guid id);
        Task<Result<IEnumerable<PatientDto>>> GetAllPatientsAsync();
        Task<Result<PatientDto>> CreatePatientAsync(RegisterPatientDto registerPatientDto);
        Task<Result<PatientDto>> UpdatePatientAsync(PatientDto patientDto);
        Task<Result<bool>> DeletePatientAsync(Guid id);
    }
}
