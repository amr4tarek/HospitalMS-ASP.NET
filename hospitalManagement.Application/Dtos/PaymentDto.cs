using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalManagement.Application.Dtos
{
    public class PaymentDto
    {
        public Guid Id { get; set; }
        public Guid InvoiceId { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal AmountPaid { get; set; }
        public string PaymentMethod { get; set; }
        public string StripeChargeId { get; set; }  
    }

}
