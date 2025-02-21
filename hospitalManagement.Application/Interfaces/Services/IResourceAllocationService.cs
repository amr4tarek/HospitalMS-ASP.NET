using hospitalManagement.Application.Dtos;
using hospitalManagement.Application.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalManagement.Application.Interfaces.Services
{
    public interface IResourceAllocationService
    {
        Task<Result<ResourceAllocationDto>> GetResourceAllocationByIdAsync(Guid id);
        Task<Result<IEnumerable<ResourceAllocationDto>>> GetResourceAllocationsByAppointmentIdAsync(Guid appointmentId);
        Task<Result<ResourceAllocationDto>> CreateResourceAllocationAsync(ResourceAllocationDto resourceAllocationDto);
        Task<Result<ResourceAllocationDto>> UpdateResourceAllocationAsync(ResourceAllocationDto resourceAllocationDto);
        Task<Result<bool>> DeleteResourceAllocationAsync(Guid id);
    }
}
