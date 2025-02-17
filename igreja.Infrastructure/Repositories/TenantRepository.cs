using igreja.Domain.Interfaces.Repository;
using igreja.Domain.Models;
using igreja.Infrastructure.Data;
using igreja.Infrastructure.Repositories.General;
using Microsoft.EntityFrameworkCore;

namespace igreja.Infrastructure.Repositories
{
    public class TenantRepository : Repository<Tenant>, ITenantRepository
    {
        private readonly ApplicationDbContext _context;
        public TenantRepository(ApplicationDbContext context) : base(context) {
            _context = context;
        }

        //Não tem nada para implementar, pois não possui métodos especiais declarados 
        //na interface ITenantRepository (não precisa dela)

    }
}
