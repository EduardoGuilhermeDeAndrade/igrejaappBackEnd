using igreja.Domain.Models.General;

namespace igreja.Domain.Models
{
    public class Member : EntityFull
    {
        public string Name { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public string MemberFunction { get; set; } = string.Empty;
        public Guid ChurchId { get; set; }

       
    }
}
