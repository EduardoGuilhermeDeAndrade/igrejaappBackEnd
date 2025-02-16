using igreja.Domain.Interfaces;
using igreja.Domain.Models;
using igreja.Infrastructure.Data;
using igreja.Infrastructure.Repositories.General;
using Igreja.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Igreja.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserContextProvider _userContextProvider;

        public UserRepository(ApplicationDbContext context, IUserContextProvider userContextProvider) : base(context)
        {
            _context = context;
            _userContextProvider = userContextProvider;
        }

        public async Task<User?> GetUserByUsernameAsync(string username)
        {

            //IgnoreQueryFilters
            //Ignora a condição de filtro global, no login do usuário

            return await _context.Users.IgnoreQueryFilters()
                .FirstOrDefaultAsync(u => u.Username.ToLower() == username.ToLower());
        }

        public async Task<User?> GetUserByIdIgnoreFilterAsync(Guid userId)
        {
            var currentUser = _userContextProvider.GetCurrentUserId();

            return await _context.Users
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(u => u.Id == userId);
        }

        public async Task<IEnumerable<User>> GetUsersResponsableTaskAsync()
        {
            var currentUser = _userContextProvider.GetCurrentUserId();

            return await _context.Users
                .IgnoreQueryFilters() 
                .Where(u => u.IsResponsableMyTask == true & u.Deleted == false & u.Id != currentUser)
                .ToListAsync();
        }

        public async Task<User?> GetByIdIgnoreQueryFilterAsync(Guid userId)
        {
            return await _context.Users
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(u => u.Id == userId);
        }

    }
}
