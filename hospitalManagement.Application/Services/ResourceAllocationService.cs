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
    public class ResourceAllocationService : IResourceAllocationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ResourceAllocationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<ResourceAllocationDto>> GetResourceAllocationByIdAsync(Guid id)
        {
            var allocation = await _unitOfWork.ResourceAllocations.GetByIdAsync(id);
            if (allocation == null)
                return Result<ResourceAllocationDto>.FailureResult("Resource allocation not found");
            var dto = _mapper.Map<ResourceAllocationDto>(allocation);
            return Result<ResourceAllocationDto>.SuccessResult(dto, "Resource allocation retrieved successfully");
        }

        public async Task<Result<IEnumerable<ResourceAllocationDto>>> GetResourceAllocationsByAppointmentIdAsync(Guid appointmentId)
        {
            var appointment = await _unitOfWork.Appointments.GetByIdAsync(appointmentId);
            if (appointment == null)
                return Result<IEnumerable<ResourceAllocationDto>>.FailureResult("Appointment not found");
            var dtos = _mapper.Map<IEnumerable<ResourceAllocationDto>>(appointment.ResourceAllocations);
            return Result<IEnumerable<ResourceAllocationDto>>.SuccessResult(dtos, "Resource allocations retrieved successfully");
        }

        public async Task<Result<ResourceAllocationDto>> CreateResourceAllocationAsync(ResourceAllocationDto resourceAllocationDto)
        {
            var allocation = _mapper.Map<Domain.Models.ResourceAllocation>(resourceAllocationDto);
            await _unitOfWork.ResourceAllocations.AddAsync(allocation);
            await _unitOfWork.CommitAsync();
            var createdDto = _mapper.Map<ResourceAllocationDto>(allocation);
            return Result<ResourceAllocationDto>.SuccessResult(createdDto, "Resource allocation created successfully");
        }

        public async Task<Result<ResourceAllocationDto>> UpdateResourceAllocationAsync(ResourceAllocationDto resourceAllocationDto)
        {
            var allocation = await _unitOfWork.ResourceAllocations.GetByIdAsync(resourceAllocationDto.Id);
            if (allocation == null)
                return Result<ResourceAllocationDto>.FailureResult("Resource allocation not found");
            _mapper.Map(resourceAllocationDto, allocation);
            await _unitOfWork.ResourceAllocations.UpdateAsync(allocation);
            await _unitOfWork.CommitAsync();
            var updatedDto = _mapper.Map<ResourceAllocationDto>(allocation);
            return Result<ResourceAllocationDto>.SuccessResult(updatedDto, "Resource allocation updated successfully");
        }

        public async Task<Result<bool>> DeleteResourceAllocationAsync(Guid id)
        {
            var allocation = await _unitOfWork.ResourceAllocations.GetByIdAsync(id);
            if (allocation == null)
                return Result<bool>.FailureResult("Resource allocation not found");
            await _unitOfWork.ResourceAllocations.DeleteAsync(allocation);
            await _unitOfWork.CommitAsync();
            return Result<bool>.SuccessResult(true, "Resource allocation deleted successfully");
        }
    }
}
