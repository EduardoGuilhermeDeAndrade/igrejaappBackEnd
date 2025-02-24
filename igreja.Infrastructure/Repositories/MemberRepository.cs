using igreja.Domain.Interfaces;
using igreja.Domain.Models;
using igreja.Infrastructure.Data;
using igreja.Infrastructure.Repositories.General;
using Microsoft.EntityFrameworkCore;
using System;

namespace igreja.Infrastructure.Repositories
{
    public class MemberRepository : Repository<Member>, IMemberRepository
    {
        private readonly ApplicationDbContext _context;
        public MemberRepository(ApplicationDbContext context) : base(context) {
            _context = context;
        }


        public async Task<IEnumerable<Member>> GetByChurchIdAsync(Guid churchId)
        {
            return await _context.Members.Where(m => m.IgrejaTenantId == churchId).ToListAsync();
        }
    }
}
