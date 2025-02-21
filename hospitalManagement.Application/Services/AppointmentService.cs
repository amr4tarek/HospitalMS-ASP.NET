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
    public class AppointmentService : IAppointmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AppointmentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<AppointmentDto>> GetAppointmentByIdAsync(Guid id)
        {
            var appointment = await _unitOfWork.Appointments.GetByIdAsync(id);
            if (appointment == null)
            {
                return Result<AppointmentDto>.FailureResult("Appointment not found");
            }
            var dto = _mapper.Map<AppointmentDto>(appointment);
            return Result<AppointmentDto>.SuccessResult(dto, "Appointment retrieved successfully");
        }

        public async Task<Result<IEnumerable<AppointmentDto>>> GetAppointmentsByDoctorIdAsync(Guid doctorId)
        {
            var appointments = await _unitOfWork.Appointments.GetAppointmentsByDoctorIdAsync(doctorId);
            var dtos = _mapper.Map<IEnumerable<AppointmentDto>>(appointments);
            return Result<IEnumerable<AppointmentDto>>.SuccessResult(dtos, "Appointments retrieved successfully");
        }

        public async Task<Result<IEnumerable<AppointmentDto>>> GetAppointmentsByPatientIdAsync(Guid patientId)
        {
            var appointments = await _unitOfWork.Appointments.GetAppointmentsByPatientIdAsync(patientId);
            var dtos = _mapper.Map<IEnumerable<AppointmentDto>>(appointments);
            return Result<IEnumerable<AppointmentDto>>.SuccessResult(dtos, "Appointments retrieved successfully");
        }

        public async Task<Result<AppointmentDto>> CreateAppointmentAsync(AppointmentDto appointmentDto)
        {
            var appointment = _mapper.Map<Domain.Models.Appointment>(appointmentDto);
            await _unitOfWork.Appointments.AddAsync(appointment);
            await _unitOfWork.CommitAsync();
            var createdDto = _mapper.Map<AppointmentDto>(appointment);
            return Result<AppointmentDto>.SuccessResult(createdDto, "Appointment created successfully");
        }

        public async Task<Result<AppointmentDto>> UpdateAppointmentAsync(AppointmentDto appointmentDto)
        {
            var appointment = await _unitOfWork.Appointments.GetByIdAsync(appointmentDto.Id);
            if (appointment == null)
            {
                return Result<AppointmentDto>.FailureResult("Appointment not found");
            }
            _mapper.Map(appointmentDto, appointment);
            await _unitOfWork.Appointments.UpdateAsync(appointment);
            await _unitOfWork.CommitAsync();
            var updatedDto = _mapper.Map<AppointmentDto>(appointment);
            return Result<AppointmentDto>.SuccessResult(updatedDto, "Appointment updated successfully");
        }

        public async Task<Result<bool>> DeleteAppointmentAsync(Guid id)
        {
            var appointment = await _unitOfWork.Appointments.GetByIdAsync(id);
            if (appointment == null)
            {
                return Result<bool>.FailureResult("Appointment not found");
            }
            await _unitOfWork.Appointments.DeleteAsync(appointment);
            await _unitOfWork.CommitAsync();
            return Result<bool>.SuccessResult(true, "Appointment deleted successfully");
        }
    }
}
