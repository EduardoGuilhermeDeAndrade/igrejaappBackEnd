using System.ComponentModel.DataAnnotations;

namespace igreja.Application.DTOs.Tenant
{
    public class TenantAddDto
    {
        [Required]
        public string Name { get; set; }

       
    }
}
