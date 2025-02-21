using hospitalManagement.Domain.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalManagement.Application.Interfaces.Repos
{
    public interface IPatientRepository : IRepository<Patient>
    {
        Task<Patient> GetPatientByUserIdAsync(Guid applicationUserId);
    }
}
