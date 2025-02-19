using igreja.Application.DTOs.Tenant;
using igreja.Domain.Common;

namespace igreja.Application.Interfaces
{
    public interface IIgrejaTenantService
    {
        Task<ApiResponse<IEnumerable<IgrejaTenantDto>>> GetAllTenantsAsync();
        Task<ApiResponse<IgrejaTenantDto?>> GetTenatByIdAsync(Guid id);
        Task<ApiResponse<bool>> AddTenatAsync(IgrejaTenantAddDto templeAddDto);
        Task<ApiResponse<bool>> UpdateTenantAsync(Guid id, IgrejaTenantUpdateDto templeUpdateDto);
        Task<ApiResponse<bool>> DeleteTenantAsync(Guid id);

    }
}
