using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hospitalManagement.Domain.Models.Users;

namespace hospitalManagement.Domain.Models
{
    public class MedicalRecord : BaseEntity
    {
        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }

        public Guid DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public DateTime VisitDate { get; set; }
        public string Diagnosis { get; set; }
        public string TreatmentPlan { get; set; }
        public string PrescriptionDetails { get; set; }
        public string Notes { get; set; }

        public ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
    }
}
