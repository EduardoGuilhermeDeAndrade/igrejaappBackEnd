using System.ComponentModel.DataAnnotations;

namespace igreja.Application.DTOs.MyTask
{
    public class MyTaskDeleteDto
    {
        [Required]
        public Guid Id { get; set; }

    }
}
