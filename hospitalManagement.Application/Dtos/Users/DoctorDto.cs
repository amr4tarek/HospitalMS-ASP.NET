using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalManagement.Application.Dtos.Users
{
    public class DoctorDto
    {
        public Guid Id { get; set; }
        public string Specialization { get; set; }
        public string Qualifications { get; set; }
        public int YearsOfExperience { get; set; }
        public string ClinicAddress { get; set; }

        public ApplicationUserDto ApplicationUser { get; set; }

        public ICollection<AppointmentDto> Appointments { get; set; }
        public ICollection<MedicalRecordDto> MedicalRecords { get; set; }
        public ICollection<LabTestDto> LabTests { get; set; }
    }
}
