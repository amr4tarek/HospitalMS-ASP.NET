using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalManagement.Domain.Models.Users
{
    public class Patient : BaseEntity
    {
        public Guid ApplicationUserId { get; set; }
        public User ApplicationUser { get; set; }

        
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }          
        public string ContactNumber { get; set; }     
        public string InsuranceDetails { get; set; }
        public string EmergencyContact { get; set; }

        public ICollection<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
        public ICollection<LabTest> LabTests { get; set; } = new List<LabTest>();
    }
}
