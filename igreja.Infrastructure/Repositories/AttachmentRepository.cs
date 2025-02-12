using igreja.Domain.Interfaces.Repository;
using igreja.Domain.Models;
using igreja.Infrastructure.Data;
using igreja.Infrastructure.Repositories.General;
using Microsoft.EntityFrameworkCore;

namespace igreja.Infrastructure.Repositories
{
    public class AttachmentRepository : Repository<Attachment>, IAttachmentRepository
    {
        private readonly ApplicationDbContext _context;

        public AttachmentRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddAsync(Attachment attachment)
        {
            await _context.Set<Attachment>().AddAsync(attachment);
            await _context.SaveChangesAsync();
        }

        public async Task<Attachment?> GetByIdAsync(Guid id)
        {
            return await _context.Set<Attachment>().FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Attachment>> GetAllAsync()
        {
            return await _context.Set<Attachment>().ToListAsync();
        }
    }
}
