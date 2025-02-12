using igreja.Domain.Models;

namespace Igreja.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetUserByUsernameAsync(string username);
        Task<IEnumerable<User>> GetUsersResponsableTaskAsync();
        Task<User?> GetByIdIgnoreQueryFilterAsync(Guid userId);
        Task<User?> GetUserByIdIgnoreFilterAsync(Guid userId);


    }
}
