using igreja.Application.DTOs.Church;
using igreja.Domain.Common;

namespace igreja.Application.Interfaces
{
    public interface IChurchService
    {
        Task<ApiResponse<IEnumerable<ChurchDto>>> GetAllChurchsAsync();
        Task<ApiResponse<IEnumerable<ChurchWithTempleDto>>> GetAllWithTemplesNameAsync();
        Task<ApiResponse<ChurchDto?>> GetChurchByIdAsync(Guid id);
        Task<ApiResponse<bool>> AddChurchAsync(ChurchAddDto churchAddDto);
        Task<ApiResponse<bool>> UpdateChurchAsync(Guid id, ChurchUpdateDto churchUpdateDto);
        Task<ApiResponse<bool>> DeleteChurchAsync(Guid id);
    }
}
