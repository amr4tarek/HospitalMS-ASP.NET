using hospitalManagement.Application.Interfaces.Repos;
using hospitalManagement.Domain.Models;
using hospitalManagement.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalManagement.Infrastructure.Repos
{
    public class ResourceAllocationRepository : Repository<ResourceAllocation>, IResourceAllocationRepository
    {
        public ResourceAllocationRepository(HMDbContext context)
            : base(context)
        {
        }


    }
}
