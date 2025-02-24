using igreja.Domain.Models.General;
using System;
using System.Net.Mail;

namespace igreja.Domain.Models
{
    public class User: EntityTenantUser
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }
        public EnumNivelAcesso NivelAcesso { get; set; }
        public bool IsResponsableMyTask { get; set; } = false;

        ////public Guid? MemberId { get; set; } // Pode ou não estar vinculado a um membro
        //public Member Member { get; set; }

        public Guid IgrejaTenantId { get; set; }
        public IgrejaTenant IgrejaTenans { get; set; }

        // Relacionamento opcional com Attachments (foto de perfil)
        public Guid? AttachmentId { get; set; }
        public Attachment Attachment { get; set; }
    }
}

