using AutoMapper;
using igreja.Application.DTOs.Church;
using igreja.Application.DTOs.Temple;
using igreja.Domain.Models;

namespace igreja.Application.Mappings
{
    public class TempleMapping : Profile
    {
        public TempleMapping()
        {
            // Mapeamento bidirecional entre Church e ChurchDto
            CreateMap<Temple, TempleDto>().ReverseMap();
            CreateMap<Temple, TempleAddDto>().ReverseMap();
            CreateMap<Temple, TempleUpdateDto>().ReverseMap();

            // Ignora propriedades específicas durante a conversão de entrada
            CreateMap<TempleDto, Temple>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Created, opt => opt.Ignore())
                .ForMember(dest => dest.Changed, opt => opt.Ignore());

        }

    }
}
