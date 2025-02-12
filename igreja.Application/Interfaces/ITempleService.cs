using igreja.Application.DTOs.Temple;
using igreja.Domain.Common;

namespace igreja.Application.Interfaces
{
    public interface ITempleService
    {
        Task<ApiResponse<IEnumerable<TempleDto>>> GetAllTemplesAsync();
        Task<ApiResponse<TempleDto?>> GetTempleByIdAsync(Guid id);
        Task<ApiResponse<IEnumerable<TempleDto>>> GetTemplesByChurchAsync(Guid churchId);
        Task<ApiResponse<bool>> AddTempleAsync(TempleAddDto templeAddDto);
        Task<ApiResponse<bool>> UpdateTempleAsync(Guid id, TempleUpdateDto templeUpdateDto);
        Task<ApiResponse<bool>> DeleteTempleAsync(Guid id);

    }
}
