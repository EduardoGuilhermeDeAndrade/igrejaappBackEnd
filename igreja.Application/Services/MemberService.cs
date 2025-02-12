using AutoMapper;
using igreja.Application.DTOs;
using igreja.Application.Interfaces;
using igreja.Domain.Common;
using igreja.Domain.Interfaces;
using igreja.Domain.Models;

namespace igreja.Application.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IMapper _mapper;

        public MemberService(IMemberRepository memberRepository, IMapper mapper)
        {
            _memberRepository = memberRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<IEnumerable<MemberDto>>> GetAllMembersAsync()
        {
            var members = await _memberRepository.GetAllAsync();

            var membersDtoList = _mapper.Map<IEnumerable<MemberDto>>(members);

            return new ApiResponse<IEnumerable<MemberDto>>(membersDtoList);
        }

        public async Task<ApiResponse<MemberDto?>> GetMemberByIdAsync(Guid id)
        {
            var member = await _memberRepository.GetByIdAsync(id);

            if (member == null)
                throw new KeyNotFoundException("Member não encontrado.");

            var memberDto = _mapper.Map<MemberDto>(member);

            return new ApiResponse<MemberDto?>(memberDto);
        }

        public async Task<ApiResponse<IEnumerable<MemberDto>>> GetMembersByChurchAsync(Guid igrejaId)
        {
            var members = await _memberRepository.GetByChurchIdAsync(igrejaId);

            var membersDtoList = _mapper.Map<IEnumerable<MemberDto>>(members);

            return new ApiResponse<IEnumerable<MemberDto>>(membersDtoList);
        }

        public async Task<ApiResponse<bool>> AddMemberAsync(MemberAddDto memberAddDto)
        {
            var member = _mapper.Map<Member>(memberAddDto);
            await _memberRepository.AddAsync(member);

            return new ApiResponse<bool>( true);
        }

        public async Task<ApiResponse<bool>> UpdateMemberAsync(Guid id, MemberUpdateDto memberUpdateDto)
        {
            var member = await _memberRepository.GetByIdAsync(id);
            if (member == null)
                throw new KeyNotFoundException("Member não encontrado.");

            _mapper.Map(memberUpdateDto, member);
            await _memberRepository.UpdateAsync(member);

            return new ApiResponse<bool>(true);
        }

        public async Task<ApiResponse<bool>> DeleteMemberAsync(Guid id)
        {
            var member = await _memberRepository.GetByIdAsync(id);
            if (member == null)
                throw new KeyNotFoundException("Member não encontrado.");

            await _memberRepository.DeleteAsync(id);

            return new ApiResponse<bool>(true);
        }


    }
}
