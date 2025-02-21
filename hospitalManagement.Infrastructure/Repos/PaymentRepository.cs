using hospitalManagement.Application.Interfaces.Repos;
using hospitalManagement.Domain.Models;
using hospitalManagement.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalManagement.Infrastructure.Repos
{
    public class PaymentRepository : Repository<Payment>, IPaymentRepository
    {
        public PaymentRepository(HMDbContext context)
            : base(context)
        {
        }

    }
}
