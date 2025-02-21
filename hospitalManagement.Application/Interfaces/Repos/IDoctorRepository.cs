using hospitalManagement.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalManagement.Application.Interfaces.Repos
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
        Task<Doctor> GetDoctorByUserIdAsync(Guid applicationUserId);

      //  Task<IEnumerable<Doctor>> GetDoctorsByDepartmentIdAsync(Guid departmentId);


    }
}
