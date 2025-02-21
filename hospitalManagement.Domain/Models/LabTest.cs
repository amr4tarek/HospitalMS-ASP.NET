using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hospitalManagement.Domain.Models.Users;

namespace hospitalManagement.Domain.Models
{
    public class LabTest : BaseEntity
    {
        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }

        public Guid OrderedByDoctorId { get; set; }
        public Doctor OrderedByDoctor { get; set; }

        public string TestType { get; set; }
        public DateTime OrderedDate { get; set; }
        public DateTime? ResultDate { get; set; }
        public string Status { get; set; } // e.g., Pending, Completed, Cancelled.
        public string Results { get; set; }
    }
}
