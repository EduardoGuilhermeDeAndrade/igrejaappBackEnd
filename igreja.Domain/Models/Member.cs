using igreja.Domain.Models.General;

namespace igreja.Domain.Models
{
    public class Member : Entity
    {
        public string Name { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public string MemberFunction { get; set; } = string.Empty;
        public Guid ChurchId { get; set; }

        // Navegação
        public Church Church { get; set; }
        public ICollection<FinancialMovement> FinancialMovements { get; set; } = new List<FinancialMovement>();
    }
}
