namespace igreja.Domain.Models.General
{

    public abstract class EntityUser
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid UserId { get; set; } // Relacionamento com o usuário

        public Guid TenantId { get; set; } // Relacionamento com o usuário

        public DateTime Created { get; set; } = DateTime.UtcNow; 

        public DateTime? Changed { get; set; } 

        public bool Deleted { get; set; } = false; 

        protected EntityUser() { }

        protected EntityUser(Guid id)
        {
            Id = id;
        }
    }


}
