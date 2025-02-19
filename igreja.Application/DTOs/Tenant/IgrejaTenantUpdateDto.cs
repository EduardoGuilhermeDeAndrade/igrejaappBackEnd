using System.ComponentModel.DataAnnotations;

namespace igreja.Application.DTOs.Tenant
{
    public class IgrejaTenantUpdateDto
    {
        [Required]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
