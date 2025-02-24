using igreja.Domain.Models.General;
using System.Net.Mail;

namespace igreja.Domain.Models
{
    public class Temple : EntityTenantUser
    {
        public string Name { get; set; }

        // Relacionamentos
        public Guid IgrejaId { get; set; }
        public IgrejaTenant IgrejaTenant { get; set; }

        // Propriedade de navegação para Address
        // Chave estrangeira opcional (se o Temple for o lado dependente)
        public Guid? AddressId { get; set; }
        public Address Address { get; set; }


        public Guid? AttachmentId { get; set; }
        public Attachment Attachment { get; set; }
    }
}
