using System.ComponentModel.DataAnnotations;

namespace igreja.Application.DTOs.Temple
{
    public class TempleUpdateDto
    {
        [Required]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
    }
}
