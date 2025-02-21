using AutoMapper;
using hospitalManagement.Application.Dtos;
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
    public class PrescriptionService : IPrescriptionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PrescriptionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<PrescriptionDto>> GetPrescriptionByIdAsync(Guid id)
        {
            var prescription = await _unitOfWork.Prescriptions.GetByIdAsync(id);
            if (prescription == null)
                return Result<PrescriptionDto>.FailureResult("Prescription not found");
            var dto = _mapper.Map<PrescriptionDto>(prescription);
            return Result<PrescriptionDto>.SuccessResult(dto, "Prescription retrieved successfully");
        }

        public async Task<Result<IEnumerable<PrescriptionDto>>> GetPrescriptionsByMedicalRecordIdAsync(Guid medicalRecordId)
        {

            var record = await _unitOfWork.MedicalRecords.GetByIdAsync(medicalRecordId);
            if (record == null)
                return Result<IEnumerable<PrescriptionDto>>.FailureResult("Medical record not found");
            var dtos = _mapper.Map<IEnumerable<PrescriptionDto>>(record.Prescriptions);
            return Result<IEnumerable<PrescriptionDto>>.SuccessResult(dtos, "Prescriptions retrieved successfully");
        }

        public async Task<Result<PrescriptionDto>> CreatePrescriptionAsync(PrescriptionDto prescriptionDto)
        {
            var prescription = _mapper.Map<Domain.Models.Prescription>(prescriptionDto);
            await _unitOfWork.Prescriptions.AddAsync(prescription);
            await _unitOfWork.CommitAsync();
            var createdDto = _mapper.Map<PrescriptionDto>(prescription);
            return Result<PrescriptionDto>.SuccessResult(createdDto, "Prescription created successfully");
        }

        public async Task<Result<PrescriptionDto>> UpdatePrescriptionAsync(PrescriptionDto prescriptionDto)
        {
            var prescription = await _unitOfWork.Prescriptions.GetByIdAsync(prescriptionDto.Id);
            if (prescription == null)
                return Result<PrescriptionDto>.FailureResult("Prescription not found");
            _mapper.Map(prescriptionDto, prescription);
            await _unitOfWork.Prescriptions.UpdateAsync(prescription);
            await _unitOfWork.CommitAsync();
            var updatedDto = _mapper.Map<PrescriptionDto>(prescription);
            return Result<PrescriptionDto>.SuccessResult(updatedDto, "Prescription updated successfully");
        }

        public async Task<Result<bool>> DeletePrescriptionAsync(Guid id)
        {
            var prescription = await _unitOfWork.Prescriptions.GetByIdAsync(id);
            if (prescription == null)
                return Result<bool>.FailureResult("Prescription not found");
            await _unitOfWork.Prescriptions.DeleteAsync(prescription);
            await _unitOfWork.CommitAsync();
            return Result<bool>.SuccessResult(true, "Prescription deleted successfully");
        }
    }
}
