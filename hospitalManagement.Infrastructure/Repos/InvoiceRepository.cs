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
    public class InvoiceRepository : Repository<Invoice>, IInvoiceRepository
    {
        public InvoiceRepository(HMDbContext context)
            : base(context)
        {
        }

        public async Task<IEnumerable<Invoice>> GetInvoicesByPatientIdAsync(Guid patientId)
        {
            return await _context.Invoices
                                 .Include(i => i.Patient)
                                 .Where(i => i.PatientId == patientId)
                                 .ToListAsync();
        }
    }
}
