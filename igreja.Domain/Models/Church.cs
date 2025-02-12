using igreja.Domain.Models.General;
using System;

namespace igreja.Domain.Models
{
    public class Church : Entity
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        // Navegação
        public ICollection<Temple> Temples { get; set; } = new List<Temple>();
        public ICollection<Member> Members { get; set; } = new List<Member>();
    }
}
