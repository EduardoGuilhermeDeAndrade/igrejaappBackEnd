using igreja.Application.DTOs.Temple;

namespace igreja.Application.DTOs.Church
{
    public class ChurchWithTempleDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public ICollection<TempleDto> Temples { get; set; } = new List<TempleDto>();
    }
}
