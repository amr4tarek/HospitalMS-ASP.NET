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
    public class StaffScheduleRepository : Repository<StaffSchedule>, IStaffScheduleRepository
    {
        public StaffScheduleRepository(HMDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<StaffSchedule>> GetSchedulesByStaffIdAsync(Guid staffId)
        {
            return await _context.StaffSchedules
                                 .Where(s => s.StaffId == staffId)
                                 .ToListAsync();
        }
    }
}
