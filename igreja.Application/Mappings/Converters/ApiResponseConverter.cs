using AutoMapper;
using igreja.Domain.Common;

namespace igreja.Application.Mappings.Converters
{
    // Conversor genérico para ApiResponse<T>
    public class ApiResponseConverter<TSource, TDestination>
        : ITypeConverter<IEnumerable<TSource>, ApiResponse<IEnumerable<TDestination>>>
    {
        private readonly IMapper _mapper;

        public ApiResponseConverter(IMapper mapper)
        {
            _mapper = mapper;
        }

        public ApiResponse<IEnumerable<TDestination>> Convert(
            IEnumerable<TSource> source,
            ApiResponse<IEnumerable<TDestination>> destination,
            ResolutionContext context)
        {
            // Converte a lista TSource para TDestination
            var mappedItems = _mapper.Map<IEnumerable<TDestination>>(source);
            return new ApiResponse<IEnumerable<TDestination>>(mappedItems, true, "Dados obtidos com sucesso.");
        }
    }
}
