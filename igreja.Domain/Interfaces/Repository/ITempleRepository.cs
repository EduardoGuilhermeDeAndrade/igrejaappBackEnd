using igreja.Domain.Models;
using Igreja.Domain.Interfaces;

namespace igreja.Domain.Interfaces.Repository
{
    public interface ITempleRepository : IRepository<Temple>
    {
        Task<IEnumerable<Temple>> GetByChurchIdAsync(Guid churchId);
    }
}
