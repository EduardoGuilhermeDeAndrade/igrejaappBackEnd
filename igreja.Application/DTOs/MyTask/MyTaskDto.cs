using System.ComponentModel.DataAnnotations;

namespace igreja.Application.DTOs.MyTask
{
    public class MyTaskDto
    {

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        public Guid UserResponsableId { get; set; }
        public Guid UserId { get; set; }
    }
}
