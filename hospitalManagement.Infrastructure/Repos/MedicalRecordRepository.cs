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
    public class MedicalRecordRepository : Repository<MedicalRecord>, IMedicalRecordRepository
    {
        public MedicalRecordRepository(HMDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<MedicalRecord>> GetMedicalRecordsByPatientIdAsync(Guid patientId)
        {
            return await _context.MedicalRecords
                                 .Include(m => m.Doctor)
                                 .Include(m => m.Patient)
                                 .Where(m => m.PatientId == patientId)
                                 .ToListAsync();
        }
    }
}
