using igreja.Domain.Models.General;
using System;

namespace igreja.Domain.Models
{
    public class IgrejaTenant : EntityFull
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<User> Users { get; set; } = new List<User>();
        public ICollection<Member> Members { get; set; } = new List<Member>();
        public ICollection<Temple> Temples { get; set; } = new List<Temple>();

    }
}
