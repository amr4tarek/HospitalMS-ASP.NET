using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalManagement.Domain.Models
{
    public class Prescription : BaseEntity
    {
        public Guid MedicalRecordId { get; set; }
        public MedicalRecord MedicalRecord { get; set; }

        public string MedicationDetails { get; set; }
        public string Dosage { get; set; }
        public string Frequency { get; set; }
        public string Duration { get; set; }
    }
}
