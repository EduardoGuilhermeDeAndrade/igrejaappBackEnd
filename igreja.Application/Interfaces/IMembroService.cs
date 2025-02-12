using igreja.Application.DTOs;
using igreja.Domain.Common;

namespace igreja.Application.Interfaces
{
    public interface IMemberService
    {
        Task<ApiResponse<IEnumerable<MemberDto>>> GetAllMembersAsync();
        Task<ApiResponse<MemberDto?>> GetMemberByIdAsync(Guid id);
        Task<ApiResponse<bool>> AddMemberAsync(MemberAddDto memberAddDto);
        Task<ApiResponse<bool>> UpdateMemberAsync(Guid id, MemberUpdateDto memberUpdateDto);
        Task<ApiResponse<bool>> DeleteMemberAsync(Guid id);
        Task<ApiResponse<IEnumerable<MemberDto>>> GetMembersByChurchAsync(Guid churchId);
    }
}
