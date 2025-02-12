using igreja.Domain.Interfaces.Repository;
using igreja.Domain.Models;
using igreja.Infrastructure.Data;
using igreja.Infrastructure.Repositories.General;
using Microsoft.EntityFrameworkCore;

namespace igreja.Infrastructure.Repositories
{
    public class FinancialMovementRepository : Repository<FinancialMovement>, IFinancialMovementRepository
    {
        private readonly ApplicationDbContext _context;
        public FinancialMovementRepository(ApplicationDbContext context) : base(context) {
            _context = context;
        }

        public async Task<IEnumerable<FinancialMovement>> GetByTempleIdAsync(Guid templeId)
        {
            return await _context.FinancialMovements.Where(mf => mf.TempleId == templeId).ToListAsync();
        }

        public async Task<IEnumerable<FinancialMovement>> GetByMemberIdAsync(Guid memberId)
        {
            return await _context.FinancialMovements.Where(mf => mf.MemberId == memberId).ToListAsync();
        }
    }
}
