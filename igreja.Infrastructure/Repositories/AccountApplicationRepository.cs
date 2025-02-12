using igreja.Domain.Interfaces.Repository;
using igreja.Domain.Models;
using igreja.Domain.Models.Enums;
using igreja.Infrastructure.Data;
using igreja.Infrastructure.Repositories.General;
using Microsoft.EntityFrameworkCore;

namespace igreja.Infrastructure.Repositories
{
    public class AccountApplicationRepository : Repository<AccountApplication>, IAccountApplicationRepository
    {
        private readonly ApplicationDbContext _context;
        public AccountApplicationRepository(ApplicationDbContext context) : base(context) {
            _context = context;
        }

        public async Task<IEnumerable<AccountApplication>> GetActiveAccountsAsync(StatusAccount statusAccount)
        {
            return await _context.AccountApplications.Where(ca => ca.Status == statusAccount).ToListAsync();
        }
    }
}
