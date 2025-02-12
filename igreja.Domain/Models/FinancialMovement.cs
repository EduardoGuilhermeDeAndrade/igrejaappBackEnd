using igreja.Domain.Models.General;

namespace igreja.Domain.Models
{
    public class FinancialMovement : EntityUser
    {
        public DateTime MovementDate { get; set; }
        public string MovementType { get; set; } = string.Empty; // Entrada ou Saída
        public decimal Value { get; set; }
        public string Description { get; set; } = string.Empty;
        public string ContributionType { get; set; } = string.Empty;
        public Guid TempleId { get; set; }
        public Guid? MemberId { get; set; }
        public Guid? AccountApplicationId  { get; set; }

        // Navegação
        public Temple Temple { get; set; }
        public Member Member { get; set; }
        public AccountApplication AccountApplications { get; set; }
    }
}
