using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalManagement.Application.Dtos
{
    public class ResourceAllocationDto
    {
        public Guid Id { get; set; }
        public Guid ResourceId { get; set; }
      //  public ResourceDto Resource { get; set; }
        public Guid AppointmentId { get; set; }
     //   public AppointmentDto Appointment { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
