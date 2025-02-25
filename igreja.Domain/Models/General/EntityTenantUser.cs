namespace igreja.Domain.Models.General
{

    public abstract class EntityTenantUser
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid UserId { get; set; } 

        public Guid IgrejaTenantId { get; set; } 

        public DateTime Created { get; set; } = DateTime.UtcNow; 

        public DateTime? Changed { get; set; } 

        public bool Deleted { get; set; } = false; 

    }
}
