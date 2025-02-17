using AutoMapper;
using igreja.Application.DTOs.Tenant;
using igreja.Domain.Models;

namespace igreja.Application.Mappings
{
    public class TenantMapping : Profile
    {
        public TenantMapping()
        {
            // Mapeamento bidirecional entre Church e ChurchDto
            CreateMap<Tenant, TenantDto>().ReverseMap();
            CreateMap<Tenant, TenantAddDto>().ReverseMap();
            CreateMap<Tenant, TenantUpdateDto>().ReverseMap();

            // Ignora propriedades específicas durante a conversão de entrada
            CreateMap<TenantDto, Tenant>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Created, opt => opt.Ignore())
                .ForMember(dest => dest.Changed, opt => opt.Ignore());

        }

    }
}
