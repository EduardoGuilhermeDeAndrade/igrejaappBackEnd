using igreja.Domain.Models.General;

namespace igreja.Domain.Models
{
    public class Assignment : EntityTenantUser
    {
        public string Descricao { get; set; }

        // Relacionamentos
        public Guid ResponsibilityId { get; set; }
        public Responsibility Responsibility { get; set; }

    }
}
