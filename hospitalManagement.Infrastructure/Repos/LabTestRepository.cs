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
    public class LabTestRepository : Repository<LabTest>, ILabTestRepository
    {
        public LabTestRepository(HMDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<LabTest>> GetLabTestsByPatientIdAsync(Guid patientId)
        {
            return await _context.LabTests
                                 .Include(l => l.Patient)
                                 .Include(l => l.OrderedByDoctor)
                                 .Where(l => l.PatientId == patientId)
                                 .ToListAsync();
        }
    }
}
