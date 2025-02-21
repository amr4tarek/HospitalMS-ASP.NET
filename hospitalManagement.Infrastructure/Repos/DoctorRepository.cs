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
    public class DoctorRepository : Repository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(HMDbContext context)
            : base(context)
        {
        }

        public async Task<Doctor> GetDoctorByUserIdAsync(Guid applicationUserId)
        {
            return await _context.Doctors
                                 .Include(d => d.ApplicationUser)
                                 .FirstOrDefaultAsync(d => d.ApplicationUserId == applicationUserId);
        }
    }
}
