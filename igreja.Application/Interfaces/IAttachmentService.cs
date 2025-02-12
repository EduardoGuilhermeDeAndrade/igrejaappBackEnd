using igreja.Domain.Models;
using Microsoft.AspNetCore.Http;

namespace igreja.Application.Interfaces
{
    public interface IAttachmentService
    {
        Task<Attachment> SaveAttachmentAsync(IFormFile file);

        Task<Attachment> GetAttachmentByIdAsync(Guid id);
    }
}
