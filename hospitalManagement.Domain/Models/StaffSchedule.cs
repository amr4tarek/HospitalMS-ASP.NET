using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hospitalManagement.Domain.Models.Users;

namespace hospitalManagement.Domain.Models
{
    public class StaffSchedule : BaseEntity
    {
        // Refers to any ApplicationUser in a staff role (Doctor, Nurse, Technician, etc.).
        public Guid StaffId { get; set; }
        public User Staff { get; set; }

        public DateTime ShiftStart { get; set; }
        public DateTime ShiftEnd { get; set; }
        public string AssignedDepartment { get; set; }
    }
}
