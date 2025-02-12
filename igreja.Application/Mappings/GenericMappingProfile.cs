using AutoMapper;
using igreja.Application.Mappings.Converters;
using igreja.Domain.Common;

namespace igreja.Application.Mappings
{
    public class GenericMappingProfile : Profile
    {
        public GenericMappingProfile()
        {
            // Configuração do PagedResultConverter genérico
            CreateMap(typeof(PagedResult<>), typeof(PagedResult<>))
                .ConvertUsing(typeof(PagedResultConverter<,>));

            // Configuração do ApiResponseConverter genérico
            CreateMap(typeof(IEnumerable<>), typeof(ApiResponse<>))
                .ConvertUsing(typeof(ApiResponseConverter<,>));
        }
    }
}
