using igreja.Domain.Models;
using Igreja.Domain.Interfaces;

namespace igreja.Domain.Interfaces.Repository
{
    public interface ITenantRepository : IRepository<Tenant>
    {
        //Não possui métodos especiais declarados na interface ITenantRepository
    }
}
