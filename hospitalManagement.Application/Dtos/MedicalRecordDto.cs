using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hospitalManagement.Application.Dtos.Users;

namespace hospitalManagement.Application.Dtos
{
    public class MedicalRecordDto
    {
        public Guid Id { get; set; }
        public Guid PatientId { get; set; }
        //public PatientDto Patient { get; set; }
        public Guid DoctorId { get; set; }
     //   public DoctorDto Doctor { get; set; }
        public DateTime VisitDate { get; set; }
        public string Diagnosis { get; set; }
        public string TreatmentPlan { get; set; }
        public string PrescriptionDetails { get; set; }
        public string Notes { get; set; }

        public ICollection<PrescriptionDto> Prescriptions { get; set; }
    }
}
