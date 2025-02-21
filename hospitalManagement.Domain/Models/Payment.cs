using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalManagement.Domain.Models
{
    public class Payment : BaseEntity
    {
        public Guid InvoiceId { get; set; }
        public Invoice Invoice { get; set; }

        public DateTime PaymentDate { get; set; }
        public decimal AmountPaid { get; set; }
        public string PaymentMethod { get; set; } // e.g., Credit Card, Cash, Insurance.

        public string StripeChargeId { get; set; }
    }
}
