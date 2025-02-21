using hospitalManagement.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalManagement.Application.Interfaces.Repos
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        Task<IEnumerable<Appointment>> GetAppointmentsByDoctorIdAsync(Guid doctorId);
        Task<IEnumerable<Appointment>> GetAppointmentsByPatientIdAsync(Guid patientId);
    }
}
