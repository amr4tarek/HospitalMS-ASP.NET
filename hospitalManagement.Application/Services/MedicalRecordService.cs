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
    public class MedicalRecordService : IMedicalRecordService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MedicalRecordService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<MedicalRecordDto>> GetMedicalRecordByIdAsync(Guid id)
        {
            var record = await _unitOfWork.MedicalRecords.GetByIdAsync(id);
            if (record == null)
                return Result<MedicalRecordDto>.FailureResult("Medical record not found");
            var dto = _mapper.Map<MedicalRecordDto>(record);
            return Result<MedicalRecordDto>.SuccessResult(dto, "Medical record retrieved successfully");
        }

        public async Task<Result<IEnumerable<MedicalRecordDto>>> GetMedicalRecordsByPatientIdAsync(Guid patientId)
        {
            var records = await _unitOfWork.MedicalRecords.GetMedicalRecordsByPatientIdAsync(patientId);
            var dtos = _mapper.Map<IEnumerable<MedicalRecordDto>>(records);
            return Result<IEnumerable<MedicalRecordDto>>.SuccessResult(dtos, "Medical records retrieved successfully");
        }

        public async Task<Result<MedicalRecordDto>> CreateMedicalRecordAsync(MedicalRecordDto medicalRecordDto)
        {
            var record = _mapper.Map<Domain.Models.MedicalRecord>(medicalRecordDto);
            await _unitOfWork.MedicalRecords.AddAsync(record);
            await _unitOfWork.CommitAsync();
            var createdDto = _mapper.Map<MedicalRecordDto>(record);
            return Result<MedicalRecordDto>.SuccessResult(createdDto, "Medical record created successfully");
        }

        public async Task<Result<MedicalRecordDto>> UpdateMedicalRecordAsync(MedicalRecordDto medicalRecordDto)
        {
            var record = await _unitOfWork.MedicalRecords.GetByIdAsync(medicalRecordDto.Id);
            if (record == null)
                return Result<MedicalRecordDto>.FailureResult("Medical record not found");
            _mapper.Map(medicalRecordDto, record);
            await _unitOfWork.MedicalRecords.UpdateAsync(record);
            await _unitOfWork.CommitAsync();
            var updatedDto = _mapper.Map<MedicalRecordDto>(record);
            return Result<MedicalRecordDto>.SuccessResult(updatedDto, "Medical record updated successfully");
        }

        public async Task<Result<bool>> DeleteMedicalRecordAsync(Guid id)
        {
            var record = await _unitOfWork.MedicalRecords.GetByIdAsync(id);
            if (record == null)
                return Result<bool>.FailureResult("Medical record not found");
            await _unitOfWork.MedicalRecords.DeleteAsync(record);
            await _unitOfWork.CommitAsync();
            return Result<bool>.SuccessResult(true, "Medical record deleted successfully");
        }
    }
}
