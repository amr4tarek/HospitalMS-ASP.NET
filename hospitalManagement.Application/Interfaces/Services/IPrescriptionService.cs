using hospitalManagement.Application.Dtos;
using hospitalManagement.Application.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalManagement.Application.Interfaces.Services
{
    public interface IPrescriptionService
    {
        Task<Result<PrescriptionDto>> GetPrescriptionByIdAsync(Guid id);
        Task<Result<IEnumerable<PrescriptionDto>>> GetPrescriptionsByMedicalRecordIdAsync(Guid medicalRecordId);
        Task<Result<PrescriptionDto>> CreatePrescriptionAsync(PrescriptionDto prescriptionDto);
        Task<Result<PrescriptionDto>> UpdatePrescriptionAsync(PrescriptionDto prescriptionDto);
        Task<Result<bool>> DeletePrescriptionAsync(Guid id);
    }
}
