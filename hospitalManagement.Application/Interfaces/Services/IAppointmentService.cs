using hospitalManagement.Application.Dtos;
using hospitalManagement.Application.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalManagement.Application.Interfaces.Services
{
    public interface IAppointmentService
    {
        Task<Result<AppointmentDto>> GetAppointmentByIdAsync(Guid id);
        Task<Result<IEnumerable<AppointmentDto>>> GetAppointmentsByDoctorIdAsync(Guid doctorId);
        Task<Result<IEnumerable<AppointmentDto>>> GetAppointmentsByPatientIdAsync(Guid patientId);
        Task<Result<AppointmentDto>> CreateAppointmentAsync(AppointmentDto appointmentDto);
        Task<Result<AppointmentDto>> UpdateAppointmentAsync(AppointmentDto appointmentDto);
        Task<Result<bool>> DeleteAppointmentAsync(Guid id);
    }
}
