namespace igreja.Domain.Models.General
{

    public abstract class EntityFull
    {
        public Guid Id { get; set; } = Guid.NewGuid(); 

        public DateTime Created { get; set; } = DateTime.UtcNow; 

        public DateTime? Changed { get; set; } 

        public bool Deleted { get; set; } = false; 

        //protected EntityFull() { }

        //protected EntityFull(Guid id)
        //{
        //    Id = id;
        //}
    }


}
