using igreja.Domain.Models;
using igreja.Domain.Models.Enums;
using Igreja.Domain.Interfaces;

namespace igreja.Domain.Interfaces.Repository
{
    public interface IAccountApplicationRepository : IRepository<AccountApplication>
    {
        Task<IEnumerable<AccountApplication>> GetActiveAccountsAsync(StatusAccount statusAccount);
    }
}
