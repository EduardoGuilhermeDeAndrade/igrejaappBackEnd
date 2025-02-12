using AutoMapper;
using igreja.Application.DTOs;
using igreja.Domain.Models;

namespace igreja.Application.Mappings
{
    public class MemberMapping : Profile
    {
        public MemberMapping()
        {
            // Mapeamento bidirecional entre Member e MemberDto
            CreateMap<Member, MemberDto>().ReverseMap();
            CreateMap<Member, MemberAddDto>().ReverseMap();
            CreateMap<Member, MemberUpdateDto>().ReverseMap();

            // Ignora propriedades específicas durante a conversão de entrada
            CreateMap<MemberDto, Member>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Created, opt => opt.Ignore())
                .ForMember(dest => dest.Changed, opt => opt.Ignore());

        }


    }
}
