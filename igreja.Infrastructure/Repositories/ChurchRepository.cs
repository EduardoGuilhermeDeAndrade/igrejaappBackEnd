using igreja.Domain.Interfaces.Repository;
using igreja.Domain.Models;
using igreja.Infrastructure.Data;
using igreja.Infrastructure.Repositories.General;
using Microsoft.EntityFrameworkCore;

namespace igreja.Infrastructure.Repositories
{
    public class ChurchRepository : Repository<Church>, IChurchRepository
    {
        private readonly ApplicationDbContext _context;
        public ChurchRepository(ApplicationDbContext context) : base(context) {
            _context = context;
        }

        public async Task<IEnumerable<Church>> GetAllWithTempleNameAsync()
        {
            return await _context.Churchs
                .Include(x => x.Temples)
                .ToListAsync();

            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Church>> GetByNameAsync(string name)
        {
            return await _context.Churchs.Where(i => i.Name.Contains(name)).ToListAsync();
        }
    }
}
