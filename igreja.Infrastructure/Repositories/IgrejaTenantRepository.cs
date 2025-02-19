using igreja.Domain.Interfaces.Repository;
using igreja.Domain.Models;
using igreja.Infrastructure.Data;
using igreja.Infrastructure.Repositories.General;
using Microsoft.EntityFrameworkCore;

namespace igreja.Infrastructure.Repositories
{
    public class IgrejaTenantRepository : Repository<IgrejaTenant>, IIgrejaTenantRepository
    {
        private readonly ApplicationDbContext _context;
        public IgrejaTenantRepository(ApplicationDbContext context) : base(context) {
            _context = context;
        }

        //Não tem nada para implementar, pois não possui métodos especiais declarados 
        //na interface ITenantRepository (não precisa dela)

    }
}
