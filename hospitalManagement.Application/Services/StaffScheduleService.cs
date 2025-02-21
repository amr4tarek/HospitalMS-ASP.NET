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
    public class StaffScheduleService : IStaffScheduleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StaffScheduleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<StaffScheduleDto>> GetStaffScheduleByIdAsync(Guid id)
        {
            var schedule = await _unitOfWork.StaffSchedules.GetByIdAsync(id);
            if (schedule == null)
                return Result<StaffScheduleDto>.FailureResult("Staff schedule not found");
            var dto = _mapper.Map<StaffScheduleDto>(schedule);
            return Result<StaffScheduleDto>.SuccessResult(dto, "Staff schedule retrieved successfully");
        }

        public async Task<Result<IEnumerable<StaffScheduleDto>>> GetSchedulesByStaffIdAsync(Guid staffId)
        {
            var schedules = await _unitOfWork.StaffSchedules.GetSchedulesByStaffIdAsync(staffId);
            var dtos = _mapper.Map<IEnumerable<StaffScheduleDto>>(schedules);
            return Result<IEnumerable<StaffScheduleDto>>.SuccessResult(dtos, "Staff schedules retrieved successfully");
        }

        public async Task<Result<StaffScheduleDto>> CreateStaffScheduleAsync(StaffScheduleDto staffScheduleDto)
        {
            var schedule = _mapper.Map<Domain.Models.StaffSchedule>(staffScheduleDto);
            await _unitOfWork.StaffSchedules.AddAsync(schedule);
            await _unitOfWork.CommitAsync();
            var createdDto = _mapper.Map<StaffScheduleDto>(schedule);
            return Result<StaffScheduleDto>.SuccessResult(createdDto, "Staff schedule created successfully");
        }

        public async Task<Result<StaffScheduleDto>> UpdateStaffScheduleAsync(StaffScheduleDto staffScheduleDto)
        {
            var schedule = await _unitOfWork.StaffSchedules.GetByIdAsync(staffScheduleDto.Id);
            if (schedule == null)
                return Result<StaffScheduleDto>.FailureResult("Staff schedule not found");
            _mapper.Map(staffScheduleDto, schedule);
            await _unitOfWork.StaffSchedules.UpdateAsync(schedule);
            await _unitOfWork.CommitAsync();
            var updatedDto = _mapper.Map<StaffScheduleDto>(schedule);
            return Result<StaffScheduleDto>.SuccessResult(updatedDto, "Staff schedule updated successfully");
        }

        public async Task<Result<bool>> DeleteStaffScheduleAsync(Guid id)
        {
            var schedule = await _unitOfWork.StaffSchedules.GetByIdAsync(id);
            if (schedule == null)
                return Result<bool>.FailureResult("Staff schedule not found");
            await _unitOfWork.StaffSchedules.DeleteAsync(schedule);
            await _unitOfWork.CommitAsync();
            return Result<bool>.SuccessResult(true, "Staff schedule deleted successfully");
        }
    }
}
