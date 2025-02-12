using System.ComponentModel.DataAnnotations;

namespace igreja.Application.DTOs.Temple
{
    public class TempleAddDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Adress { get; set; }
        [Required]
        public Guid ChurchId { get; set; }
    }
}
