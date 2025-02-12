namespace igreja.Domain.Interfaces
{
    public interface IPagedResult<T>
    {
        IEnumerable<T> Items { get; set; }
        int TotalItems { get; set; }
        int TotalPages { get; set; }
        int CurrentPage { get; set; }
        int PageSize { get; set; }
    }
}
