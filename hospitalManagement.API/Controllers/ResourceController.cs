using hospitalManagement.Application.Dtos;
using hospitalManagement.Application.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hospitalManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,Staff")]
    public class ResourceController : ControllerBase
    {
        private readonly IResourceService _resourceService;

        public ResourceController(IResourceService resourceService)
        {
            _resourceService = resourceService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetResource(Guid id)
        {
            var result = await _resourceService.GetResourceByIdAsync(id);
            if (!result.Success) return NotFound(result.Message);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllResources()
        {
            var result = await _resourceService.GetAllResourcesAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateResource([FromBody] ResourceDto resourceDto)
        {
            var result = await _resourceService.CreateResourceAsync(resourceDto);
            if (!result.Success) return BadRequest(result.Message);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateResource([FromBody] ResourceDto resourceDto)
        {
            var result = await _resourceService.UpdateResourceAsync(resourceDto);
            if (!result.Success) return BadRequest(result.Message);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResource(Guid id)
        {
            var result = await _resourceService.DeleteResourceAsync(id);
            if (!result.Success) return BadRequest(result.Message);
            return Ok(result);
        }
    }
}
