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
            return await _context.Users
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(u => u.Username.ToLower().Contains(username.ToLower()) && u.Deleted == false);
        }

        /// <summary>
        /// Retorna todos os usuários não excluídos
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public async Task<IEnumerable<User>> GetUserAllAndTenantsAsync()
        {
            return await _context.Users
                .IgnoreQueryFilters()
                .ToListAsync();
                //.FirstOrDefaultAsync(u => u.Deleted == false);
        }

        ///// <summary>
        ///// Retorna todos os usuários inclusive excluídos
        ///// </summary>
        ///// <param name="username"></param>
        ///// <returns></returns>
        //public async Task<IEnumerable<User>> GetUserAllAsync()
        //{
        //    return await _context.Users
        //        .FirstOrDefaultAsync(u => u.Deleted == false);
        //}

        ///// <summary>
        ///// Busca o usuário pelo Id ignorando o filtro de tenant
        ///// </summary>
        ///// <param name="userId"></param>
        ///// <returns></returns>
        //public async Task<User?> GetUserByIdIgnoreFilterAsync(Guid userId)
        //{
        //    var currentUser = _userContextProvider.GetCurrentUserId();

        //    return await _context.Users
        //        .IgnoreQueryFilters()
        //        .FirstOrDefaultAsync(u => u.Id == userId);
        //}

        ///// <summary>
        ///// Busca todos os usuários que são responsáveis por tarefas, não traz o próprio usuário logado
        ///// </summary>
        ///// <returns></returns>
        //public async Task<IEnumerable<User>> GetUsersResponsableTaskAsync()
        //{
        //    var currentUser = _userContextProvider.GetCurrentUserId();

        //    return await _context.Users
        //        .IgnoreQueryFilters() 
        //        .Where(u => u.IsResponsableMyTask == true & u.Deleted == false & u.Id != currentUser)
        //        .ToListAsync();
        //}

        /// <summary>
        /// Busca os usuários pelo Id ignorando o filtro de exclusão lógica, tenant
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<User?> GetUserByIdIgnoreQueryFilterAsync(Guid userId)
        {
            return await _context.Users
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(u => u.Id == userId);
        }

    }
}
