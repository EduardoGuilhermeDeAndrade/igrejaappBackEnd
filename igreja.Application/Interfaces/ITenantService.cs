using igreja.Application.DTOs.Tenant;
using igreja.Domain.Common;

namespace igreja.Application.Interfaces
{
    public interface ITenantService
    {
        Task<ApiResponse<IEnumerable<TenantDto>>> GetAllTenantsAsync();
        Task<ApiResponse<TenantDto?>> GetTenatByIdAsync(Guid id);
        Task<ApiResponse<bool>> AddTenatAsync(TenantAddDto templeAddDto);
        Task<ApiResponse<bool>> UpdateTenantAsync(Guid id, TenantUpdateDto templeUpdateDto);
        Task<ApiResponse<bool>> DeleteTenantAsync(Guid id);

    }
}
