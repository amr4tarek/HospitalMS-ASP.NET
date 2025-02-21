using AutoMapper;
using hospitalManagement.Application.Dtos;
using hospitalManagement.Application.Helpers;
using hospitalManagement.Application.Interfaces.UoW;
using hospitalManagement.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hospitalManagement.Application.Services
{
    public class ResourceService : IResourceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ResourceService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<ResourceDto>> GetResourceByIdAsync(Guid id)
        {
            var resource = await _unitOfWork.Resources.GetByIdAsync(id);
            if (resource == null)
                return Result<ResourceDto>.FailureResult("Resource not found");
            var dto = _mapper.Map<ResourceDto>(resource);
            return Result<ResourceDto>.SuccessResult(dto, "Resource retrieved successfully");
        }

        public async Task<Result<IEnumerable<ResourceDto>>> GetAllResourcesAsync()
        {
            var resources = await _unitOfWork.Resources.ListAllAsync();
            var dtos = _mapper.Map<IEnumerable<ResourceDto>>(resources);
            return Result<IEnumerable<ResourceDto>>.SuccessResult(dtos, "Resources retrieved successfully");
        }

        public async Task<Result<ResourceDto>> CreateResourceAsync(ResourceDto resourceDto)
        {
            var resource = _mapper.Map<Domain.Models.Resource>(resourceDto);
            await _unitOfWork.Resources.AddAsync(resource);
            await _unitOfWork.CommitAsync();
            var createdDto = _mapper.Map<ResourceDto>(resource);
            return Result<ResourceDto>.SuccessResult(createdDto, "Resource created successfully");
        }

        public async Task<Result<ResourceDto>> UpdateResourceAsync(ResourceDto resourceDto)
        {
            var resource = await _unitOfWork.Resources.GetByIdAsync(resourceDto.Id);
            if (resource == null)
                return Result<ResourceDto>.FailureResult("Resource not found");
            _mapper.Map(resourceDto, resource);
            await _unitOfWork.Resources.UpdateAsync(resource);
            await _unitOfWork.CommitAsync();
            var updatedDto = _mapper.Map<ResourceDto>(resource);
            return Result<ResourceDto>.SuccessResult(updatedDto, "Resource updated successfully");
        }

        public async Task<Result<bool>> DeleteResourceAsync(Guid id)
        {
            var resource = await _unitOfWork.Resources.GetByIdAsync(id);
            if (resource == null)
                return Result<bool>.FailureResult("Resource not found");
            await _unitOfWork.Resources.DeleteAsync(resource);
            await _unitOfWork.CommitAsync();
            return Result<bool>.SuccessResult(true, "Resource deleted successfully");
        }
    }
}
