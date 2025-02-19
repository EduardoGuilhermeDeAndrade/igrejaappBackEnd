using igreja.Domain.Models.General;

namespace igreja.Domain.Models
{
    public class IgrejaTenant : EntityFull
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
