using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalManagement.Application.Dtos
{
    public class PrescriptionDto
    {
        public Guid Id { get; set; }
        public Guid MedicalRecordId { get; set; }
        public string MedicationDetails { get; set; }
        public string Dosage { get; set; }
        public string Frequency { get; set; }
        public string Duration { get; set; }
    }
}
