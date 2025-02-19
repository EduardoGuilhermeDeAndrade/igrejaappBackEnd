using System.ComponentModel.DataAnnotations;

namespace igreja.Application.DTOs.Tenant
{
    public class IgrejaTenantAddDto
    {
        [Required]
        public string Name { get; set; }

       
    }
}
