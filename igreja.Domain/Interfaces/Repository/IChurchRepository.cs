using igreja.Domain.Models;
using Igreja.Domain.Interfaces;

namespace igreja.Domain.Interfaces.Repository
{
    public interface IChurchRepository : IRepository<Church>
    {
        Task<IEnumerable<Church>> GetByNameAsync(string name);
        Task<IEnumerable<Church>> GetAllWithTempleNameAsync();
    }
}
