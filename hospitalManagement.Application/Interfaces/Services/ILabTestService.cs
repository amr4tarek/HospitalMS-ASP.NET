using hospitalManagement.Application.Dtos;
using hospitalManagement.Application.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalManagement.Application.Interfaces.Services
{
    public interface ILabTestService
    {
        Task<Result<LabTestDto>> GetLabTestByIdAsync(Guid id);
        Task<Result<IEnumerable<LabTestDto>>> GetLabTestsByPatientIdAsync(Guid patientId);
        Task<Result<LabTestDto>> CreateLabTestAsync(LabTestDto labTestDto);
        Task<Result<LabTestDto>> UpdateLabTestAsync(LabTestDto labTestDto);
        Task<Result<bool>> DeleteLabTestAsync(Guid id);
    }
}
