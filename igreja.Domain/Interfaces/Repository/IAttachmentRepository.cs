using igreja.Domain.Models;

namespace igreja.Domain.Interfaces.Repository
{
    public interface IAttachmentRepository
    {
        Task AddAsync(Attachment attachment);
        Task<Attachment?> GetByIdAsync(Guid id);
        Task<IEnumerable<Attachment>> GetAllAsync();
    }
}
