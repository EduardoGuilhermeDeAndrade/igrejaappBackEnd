using igreja.Application.DTOs.Tenant;
using igreja.Application.Interfaces;
using igreja.Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace igreja.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class TenantController : ControllerBase
    {
        private readonly ITenantService _tenantService;

        public TenantController(ITenantService tenantService)
        {
            _tenantService = tenantService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tenants = await _tenantService.GetAllTenantsAsync();
            return Ok(tenants);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var tenant = await _tenantService.GetTenatByIdAsync(id);
            return Ok(tenant);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TenantAddDto tenantAddDto)
        {
            if (tenantAddDto == null)
                return BadRequest(new ApiResponse<string>("Dados inválidos para criação de templo.", false));

            var response = await _tenantService.AddTenatAsync(tenantAddDto);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] TenantUpdateDto tenantUpdateDto)
        {
            var response = await _tenantService.UpdateTenantAsync(id, tenantUpdateDto);
            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _tenantService.DeleteTenantAsync(id);
            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }
    }
}
