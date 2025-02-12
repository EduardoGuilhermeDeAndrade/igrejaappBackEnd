using igreja.Domain.Models;
using Igreja.Domain.Interfaces;

namespace igreja.Domain.Interfaces.Repository
{
    public interface IFinancialMovementRepository : IRepository<FinancialMovement>
    {
        Task<IEnumerable<FinancialMovement>> GetByTempleIdAsync(Guid templeId);
        Task<IEnumerable<FinancialMovement>> GetByMemberIdAsync(Guid memberId);
    }
}
