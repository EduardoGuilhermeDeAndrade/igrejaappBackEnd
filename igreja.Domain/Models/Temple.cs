using igreja.Domain.Models.General;

namespace igreja.Domain.Models
{
    public class Temple : Entity
    {
        public string Name { get; set; } = string.Empty;
        public string Adress { get; set; } = string.Empty;
        public Guid ChurchId { get; set; }

        // Navegação
        public Church Church { get; set; }
        public ICollection<FinancialMovement> FinancialMovements { get; set; } = new List<FinancialMovement>();
    }
}
