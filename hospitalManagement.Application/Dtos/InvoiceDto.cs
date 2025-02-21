using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hospitalManagement.Application.Dtos.Users;

namespace hospitalManagement.Application.Dtos
{
    public class InvoiceDto
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
       // public PatientDto Patient { get; set; }
        public Guid? AppointmentId { get; set; }
      //  public AppointmentDto Appointment { get; set; }
        public decimal Amount { get; set; }
        public string PaymentStatus { get; set; }  // E.g., Pending, Paid, Refunded.
        public DateTime IssuedDate { get; set; }
        public DateTime DueDate { get; set; }

        public ICollection<PaymentDto> Payments { get; set; }
    }
}
