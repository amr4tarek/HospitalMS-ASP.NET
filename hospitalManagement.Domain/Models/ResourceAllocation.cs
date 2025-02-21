using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalManagement.Domain.Models
{
    public class ResourceAllocation : BaseEntity
    {
        public Guid ResourceId { get; set; }
        public Resource Resource { get; set; }

        public Guid AppointmentId { get; set; }
        public Appointment Appointment { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
