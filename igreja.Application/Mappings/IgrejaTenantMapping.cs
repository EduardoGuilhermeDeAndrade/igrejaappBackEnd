using AutoMapper;
using igreja.Application.DTOs.Tenant;
using igreja.Domain.Models;

namespace igreja.Application.Mappings
{
    public class IgrejaTenantMapping : Profile
    {
        public IgrejaTenantMapping()
        {
            // Mapeamento bidirecional entre Church e ChurchDto
            CreateMap<IgrejaTenant, IgrejaTenantDto>().ReverseMap();
            CreateMap<IgrejaTenant, IgrejaTenantAddDto>().ReverseMap();
            CreateMap<IgrejaTenant, IgrejaTenantUpdateDto>().ReverseMap();

            // Ignora propriedades específicas durante a conversão de entrada
            CreateMap<IgrejaTenantDto, IgrejaTenant>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Created, opt => opt.Ignore())
                .ForMember(dest => dest.Changed, opt => opt.Ignore());

        }

    }
}
