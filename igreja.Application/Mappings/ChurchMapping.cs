using AutoMapper;
using igreja.Application.DTOs.Church;
using igreja.Domain.Models;

namespace igreja.Application.Mappings
{
    public class ChurchMapping : Profile
    {
        public ChurchMapping()
        {
            // Mapeamento bidirecional entre Church e ChurchDto
            CreateMap<Church, ChurchDto>().ReverseMap();
            CreateMap<Church, ChurchAddDto>().ReverseMap();
            CreateMap<Church, ChurchUpdateDto>().ReverseMap();
            CreateMap<Church, ChurchWithTempleDto>().ReverseMap();

            // Ignora propriedades específicas durante a conversão de entrada
            CreateMap<ChurchDto, Church>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Created, opt => opt.Ignore())
                .ForMember(dest => dest.Changed, opt => opt.Ignore());

        }

    }
}
