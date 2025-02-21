using hospitalManagement.Application.Dtos;
using hospitalManagement.Application.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalManagement.Application.Interfaces.Services
{
    public interface IStaffScheduleService
    {
        Task<Result<StaffScheduleDto>> GetStaffScheduleByIdAsync(Guid id);
        Task<Result<IEnumerable<StaffScheduleDto>>> GetSchedulesByStaffIdAsync(Guid staffId);
        Task<Result<StaffScheduleDto>> CreateStaffScheduleAsync(StaffScheduleDto staffScheduleDto);
        Task<Result<StaffScheduleDto>> UpdateStaffScheduleAsync(StaffScheduleDto staffScheduleDto);
        Task<Result<bool>> DeleteStaffScheduleAsync(Guid id);
    }
}
