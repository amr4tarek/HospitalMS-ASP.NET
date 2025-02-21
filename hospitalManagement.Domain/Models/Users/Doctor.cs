using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalManagement.Domain.Models.Users
{
    public class Doctor : BaseEntity
    {
        public Guid ApplicationUserId { get; set; }
        public User ApplicationUser { get; set; }

        public string Specialization { get; set; }
        public string Qualifications { get; set; }
        public int YearsOfExperience { get; set; }
        public string ClinicAddress { get; set; }

        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();

        public ICollection<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();

        public ICollection<LabTest> LabTests { get; set; } = new List<LabTest>();
    }
}
