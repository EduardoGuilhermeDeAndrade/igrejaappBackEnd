using igreja.Domain.Interfaces.Repository;
using igreja.Domain.Models;
using igreja.Infrastructure.Data;
using igreja.Infrastructure.Repositories.General;
using Microsoft.EntityFrameworkCore;

namespace igreja.Infrastructure.Repositories
{
    public class TempleRepository : Repository<Temple>, ITempleRepository
    {
        private readonly ApplicationDbContext _context;
        public TempleRepository(ApplicationDbContext context) : base(context) {
            _context = context;
        }

        public async Task<IEnumerable<Temple>> GetByChurchIdAsync(Guid churchId)
        {
            return await _context.Temples.Where(t => t.ChurchId == churchId).ToListAsync();
        }
    }
}
