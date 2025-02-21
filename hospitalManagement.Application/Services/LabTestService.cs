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
    public class LabTestService : ILabTestService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public LabTestService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<LabTestDto>> GetLabTestByIdAsync(Guid id)
        {
            var labTest = await _unitOfWork.LabTests.GetByIdAsync(id);
            if (labTest == null)
                return Result<LabTestDto>.FailureResult("Lab test not found");
            var dto = _mapper.Map<LabTestDto>(labTest);
            return Result<LabTestDto>.SuccessResult(dto, "Lab test retrieved successfully");
        }

        public async Task<Result<IEnumerable<LabTestDto>>> GetLabTestsByPatientIdAsync(Guid patientId)
        {
            var labTests = await _unitOfWork.LabTests.GetLabTestsByPatientIdAsync(patientId);
            var dtos = _mapper.Map<IEnumerable<LabTestDto>>(labTests);
            return Result<IEnumerable<LabTestDto>>.SuccessResult(dtos, "Lab tests retrieved successfully");
        }

        public async Task<Result<LabTestDto>> CreateLabTestAsync(LabTestDto labTestDto)
        {
            var labTest = _mapper.Map<Domain.Models.LabTest>(labTestDto);
            await _unitOfWork.LabTests.AddAsync(labTest);
            await _unitOfWork.CommitAsync();
            var createdDto = _mapper.Map<LabTestDto>(labTest);
            return Result<LabTestDto>.SuccessResult(createdDto, "Lab test created successfully");
        }

        public async Task<Result<LabTestDto>> UpdateLabTestAsync(LabTestDto labTestDto)
        {
            var labTest = await _unitOfWork.LabTests.GetByIdAsync(labTestDto.Id);
            if (labTest == null)
                return Result<LabTestDto>.FailureResult("Lab test not found");
            _mapper.Map(labTestDto, labTest);
            await _unitOfWork.LabTests.UpdateAsync(labTest);
            await _unitOfWork.CommitAsync();
            var updatedDto = _mapper.Map<LabTestDto>(labTest);
            return Result<LabTestDto>.SuccessResult(updatedDto, "Lab test updated successfully");
        }

        public async Task<Result<bool>> DeleteLabTestAsync(Guid id)
        {
            var labTest = await _unitOfWork.LabTests.GetByIdAsync(id);
            if (labTest == null)
                return Result<bool>.FailureResult("Lab test not found");
            await _unitOfWork.LabTests.DeleteAsync(labTest);
            await _unitOfWork.CommitAsync();
            return Result<bool>.SuccessResult(true, "Lab test deleted successfully");
        }
    }
}
