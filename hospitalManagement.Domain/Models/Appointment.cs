using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using hospitalManagement.Domain.Models.Users;

namespace hospitalManagement.Domain.Models
{
    public class Appointment : BaseEntity
    {
        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }


        public Guid DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public DateTime ScheduledDateTime { get; set; }
        public string Status { get; set; } // e.g., Scheduled, Completed, Cancelled.
        public string Reason { get; set; }

        public ICollection<ResourceAllocation> ResourceAllocations { get; set; } = new List<ResourceAllocation>();
    }
}
