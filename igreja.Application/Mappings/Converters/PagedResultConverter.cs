using AutoMapper;
using igreja.Domain.Common;

namespace igreja.Application.Mappings.Converters
{
    // Conversor genérico para PagedResult<T>
    public class PagedResultConverter<TSource, TDestination>
        : ITypeConverter<PagedResult<TSource>, PagedResult<TDestination>>
    {
        public PagedResult<TDestination> Convert(
            PagedResult<TSource> source,
            PagedResult<TDestination> destination,
            ResolutionContext context)
        {
            // Converte os itens internos de TSource para TDestination
            var items = context.Mapper.Map<IEnumerable<TDestination>>(source.Items);

            // Retorna a nova estrutura PagedResult
            return new PagedResult<TDestination>(items, source.TotalItems, source.CurrentPage, source.PageSize);
        }
    }
}
