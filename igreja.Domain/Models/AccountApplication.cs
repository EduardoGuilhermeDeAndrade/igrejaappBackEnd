using igreja.Domain.Models.Enums;
using igreja.Domain.Models.General;

namespace igreja.Domain.Models
{
    public class AccountApplication : EntityUser
    {
        public string Name { get; set; } = string.Empty;
        public string Descripton { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
        public StatusAccount Status { get; set; }

        // Propriedades de navegação
        public ICollection<FinancialMovement> FinancialMovements { get; set; } = new List<FinancialMovement>();
    }
}
