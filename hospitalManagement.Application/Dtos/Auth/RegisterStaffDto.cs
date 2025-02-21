using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalManagement.Application.Dtos.Auth
{
    public class RegisterStaffDto : RegisterDto
    {
        public string Role { get; set; }  // e.g., "Nurse", "Receptionist", "Admin", etc.
    }
}
