using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hospitalManagement.Application.Dtos.Users;

namespace hospitalManagement.Application.Dtos
{
    public class AppointmentDto
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
      //  public PatientDto Patient { get; set; }
        public Guid DoctorId { get; set; }
      //  public DoctorDto Doctor { get; set; }
        public DateTime ScheduledDateTime { get; set; }
        public string Status { get; set; }  // E.g., Scheduled, Completed, Cancelled.
        public string Reason { get; set; }
    }
}
