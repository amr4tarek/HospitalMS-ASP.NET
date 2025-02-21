using hospitalManagement.Application.Dtos;
using hospitalManagement.Application.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalManagement.Application.Interfaces.Services
{
    public interface IMedicalRecordService
    {
        Task<Result<MedicalRecordDto>> GetMedicalRecordByIdAsync(Guid id);
        Task<Result<IEnumerable<MedicalRecordDto>>> GetMedicalRecordsByPatientIdAsync(Guid patientId);
        Task<Result<MedicalRecordDto>> CreateMedicalRecordAsync(MedicalRecordDto medicalRecordDto);
        Task<Result<MedicalRecordDto>> UpdateMedicalRecordAsync(MedicalRecordDto medicalRecordDto);
        Task<Result<bool>> DeleteMedicalRecordAsync(Guid id);
    }
}
