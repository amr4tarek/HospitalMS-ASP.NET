using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hospitalManagement.Domain.Models.Users;

namespace hospitalManagement.Domain.Models
{
    public class Invoice : BaseEntity
    {
        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }

        public Guid? AppointmentId { get; set; }
        public Appointment Appointment { get; set; }

        public decimal Amount { get; set; }
        public string PaymentStatus { get; set; } // e.g., Pending, Paid, Refunded.
        public DateTime IssuedDate { get; set; }
        public DateTime DueDate { get; set; }

        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}
