using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hospitalManagement.Application.Dtos.Users;

namespace hospitalManagement.Application.Dtos
{
    public class LabTestDto
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
      //  public PatientDto Patient { get; set; }
        public Guid OrderedByDoctorId { get; set; }
      //  public DoctorDto OrderedByDoctor { get; set; }
        public string TestType { get; set; }
        public DateTime OrderedDate { get; set; }
        public DateTime? ResultDate { get; set; }
        public string Status { get; set; }  // E.g., Pending, Completed, Cancelled.
        public string Results { get; set; }
    }
}
