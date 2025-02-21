using hospitalManagement.Application.Interfaces.Repos;
using hospitalManagement.Domain.Models;
using hospitalManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalManagement.Infrastructure.Repos
{
    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(HMDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByDoctorIdAsync(Guid doctorId)
        {
            return await _context.Appointments
                                 .Include(a => a.Patient)
                                 .Include(a => a.Doctor)
                                 .Where(a => a.DoctorId == doctorId)
                                 .ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByPatientIdAsync(Guid patientId)
        {
            return await _context.Appointments
                                 .Include(a => a.Doctor)
                                 .Include(a => a.Patient)
                                 .Where(a => a.PatientId == patientId)
                                 .ToListAsync();
        }
    }
}
