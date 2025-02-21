using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalManagement.Application.Dtos.Auth
{
    public class RegisterPatientDto : RegisterDto
    {
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }        
        public string ContactNumber { get; set; }     
        public string InsuranceDetails { get; set; }
        public string EmergencyContact { get; set; }
    }
}
