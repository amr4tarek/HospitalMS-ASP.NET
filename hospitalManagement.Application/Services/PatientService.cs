using AutoMapper;
using hospitalManagement.Application.Dtos.Auth;
using hospitalManagement.Application.Dtos.Users;
using hospitalManagement.Application.Helpers;
using hospitalManagement.Application.Interfaces.Services;
using hospitalManagement.Application.Interfaces.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalManagement.Application.Services
{
    public class PatientService : IPatientService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PatientService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<PatientDto>> GetPatientByIdAsync(Guid id)
        {
            var patient = await _unitOfWork.Patients.GetByIdAsync(id);
            if (patient == null)
            {
                return Result<PatientDto>.FailureResult("Patient not found");
            }
            var dto = _mapper.Map<PatientDto>(patient);
            return Result<PatientDto>.SuccessResult(dto, "Patient retrieved successfully");
        }

        public async Task<Result<IEnumerable<PatientDto>>> GetAllPatientsAsync()
        {
            var patients = await _unitOfWork.Patients.ListAllAsync();
            var dtos = _mapper.Map<IEnumerable<PatientDto>>(patients);
            return Result<IEnumerable<PatientDto>>.SuccessResult(dtos, "Patients retrieved successfully");
        }

        public async Task<Result<PatientDto>> CreatePatientAsync(RegisterPatientDto registerPatientDto)
        {
            // Similar to authentication registration, so this might be handled there.
            return Result<PatientDto>.FailureResult("Use the registration endpoint for patients");
        }

        public async Task<Result<PatientDto>> UpdatePatientAsync(PatientDto patientDto)
        {
            var patient = await _unitOfWork.Patients.GetByIdAsync(patientDto.Id);
            if (patient == null)
            {
                return Result<PatientDto>.FailureResult("Patient not found");
            }
            _mapper.Map(patientDto, patient);
            await _unitOfWork.Patients.UpdateAsync(patient);
            await _unitOfWork.CommitAsync();
            var updatedDto = _mapper.Map<PatientDto>(patient);
            return Result<PatientDto>.SuccessResult(updatedDto, "Patient updated successfully");
        }

        public async Task<Result<bool>> DeletePatientAsync(Guid id)
        {
            var patient = await _unitOfWork.Patients.GetByIdAsync(id);
            if (patient == null)
            {
                return Result<bool>.FailureResult("Patient not found");
            }
            await _unitOfWork.Patients.DeleteAsync(patient);
            await _unitOfWork.CommitAsync();
            return Result<bool>.SuccessResult(true, "Patient deleted successfully");
        }
    }
}
