using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using hospitalManagement.Application.Dtos.Users;

namespace hospitalManagement.Application.Dtos
{
    public class StaffScheduleDto
    {
        public Guid Id { get; set; }
        public Guid StaffId { get; set; }
        // You can also include a nested ApplicationUserDto or create a StaffDto if needed.
    //    public ApplicationUserDto Staff { get; set; }
        public DateTime ShiftStart { get; set; }
        public DateTime ShiftEnd { get; set; }
        public string AssignedDepartment { get; set; }
    }
}
