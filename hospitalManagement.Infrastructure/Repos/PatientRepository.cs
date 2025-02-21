using hospitalManagement.Application.Interfaces.Repos;
using hospitalManagement.Domain.Models.Users;
using hospitalManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalManagement.Infrastructure.Repos
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        public PatientRepository(HMDbContext context)
            : base(context)
        {
        }

        public async Task<Patient> GetPatientByUserIdAsync(Guid applicationUserId)
        {
            return await _context.Patients
                                 .Include(p => p.ApplicationUser)
                                 .FirstOrDefaultAsync(p => p.ApplicationUserId == applicationUserId);
        }
    }
}
