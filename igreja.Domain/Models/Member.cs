using igreja.Domain.Models.General;
using System.Net.Mail;

namespace igreja.Domain.Models
{
    public class Member : EntityTenantUser
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string CPF { get; set; } = string.Empty;
        public string MemberFunction { get; set; } = string.Empty;

        // Relacionamentos
        public Guid IgrejaTenantId { get; set; }
        public IgrejaTenant IgrejaTenant { get; set; }

        // Propriedade de navegação para Address
        // Chave estrangeira opcional (se o Member for o lado dependente)
        public Guid? AddressId { get; set; }
        public Address Address { get; set; }
        
        public Guid? ResponsibilityId { get; set; }
        public Responsibility Responsibility { get; set; }

        public Guid? AttachmentId { get; set; }
        public Attachment Attachment { get; set; }

    }
}
