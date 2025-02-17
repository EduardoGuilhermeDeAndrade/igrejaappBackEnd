using igreja.Domain.Models;

namespace Igreja.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetUserByUsernameAsync(string username);
        Task<IEnumerable<User>> GetUserAllAndTenantsAsync();
        //Task<IEnumerable<User>> GetUserAllAsync();
        //Task<User?> GetUserByIdIgnoreFilterAsync(Guid userId);
        //Task<IEnumerable<User>> GetUsersResponsableTaskAsync();
        Task<User?> GetUserByIdIgnoreQueryFilterAsync(Guid userId);


    }
}
