using igreja.Domain.Models.General;

namespace igreja.Domain.Models
{
    public class Address: EntityTenantUser
    {
        public string City { get; set; }
        public string District { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }

        // Relacionamentos
        public Member? Member { get; set; }
        public Temple? Temple { get; set; }

    }
}
