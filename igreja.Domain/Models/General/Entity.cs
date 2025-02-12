namespace igreja.Domain.Models.General
{

    public abstract class Entity
    {
        public Guid Id { get; set; } = Guid.NewGuid(); 

        public DateTime Created { get; set; } = DateTime.UtcNow; 

        public DateTime? Changed { get; set; } 

        public bool Deleted { get; set; } = false; 

        protected Entity() { }

        protected Entity(Guid id)
        {
            Id = id;
        }
    }


}
