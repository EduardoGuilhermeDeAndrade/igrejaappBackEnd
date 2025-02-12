namespace igreja.Application.DTOs
{
    public class MemberAddDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public string MemberFunction { get; set; } = string.Empty;
        public string ChurchName { get; set; } = string.Empty;
        public Guid ChurchId { get; set; }

    }
}
