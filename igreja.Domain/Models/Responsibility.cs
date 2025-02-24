using igreja.Domain.Models.General;

namespace igreja.Domain.Models
{
    public class Responsibility : EntityTenantUser
    {
        public string Nome { get; set; }

        // Relacionamentos
        public ICollection<Assignment> Assignments { get; set; } = new List<Assignment>();
        public ICollection<Member> Members { get; set; } = new List<Member>();

    }
}
