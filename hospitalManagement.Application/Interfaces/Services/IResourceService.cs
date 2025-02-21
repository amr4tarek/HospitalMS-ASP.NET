using hospitalManagement.Application.Dtos;
using hospitalManagement.Application.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalManagement.Application.Interfaces.Services
{
    public interface IResourceService
    {
        Task<Result<ResourceDto>> GetResourceByIdAsync(Guid id);
        Task<Result<IEnumerable<ResourceDto>>> GetAllResourcesAsync();
        Task<Result<ResourceDto>> CreateResourceAsync(ResourceDto resourceDto);
        Task<Result<ResourceDto>> UpdateResourceAsync(ResourceDto resourceDto);
        Task<Result<bool>> DeleteResourceAsync(Guid id);
    }
}
