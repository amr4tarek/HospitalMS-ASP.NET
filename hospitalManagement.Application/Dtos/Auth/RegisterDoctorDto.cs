using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalManagement.Application.Dtos.Auth
{
    public class RegisterDoctorDto : RegisterDto
    {
        public string Specialization { get; set; }
        public string Qualifications { get; set; }
        public int YearsOfExperience { get; set; }
        public string ClinicAddress { get; set; }
    }
}
