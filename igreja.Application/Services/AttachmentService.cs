using igreja.Application.Interfaces;
using igreja.Domain.Interfaces.Repository;
using igreja.Domain.Models;
using Microsoft.AspNetCore.Http;

namespace igreja.Application.Services
{
    public class AttachmentService : IAttachmentService
    {
        private readonly IAttachmentRepository _attachmentRepository;

        public AttachmentService(IAttachmentRepository attachmentRepository)
        {
            _attachmentRepository = attachmentRepository;
        }

        public async Task<Attachment> GetAttachmentByIdAsync(Guid id)
        {
            return await _attachmentRepository.GetByIdAsync(id);
        }

        public async Task<Attachment> SaveAttachmentAsync(IFormFile file)
        {
            using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);

            var attachment = new Attachment
            {
                Id = Guid.NewGuid(),
                FileName = file.FileName,
                ContentType = file.ContentType,
                Data = memoryStream.ToArray(),
                UploadedAt = DateTime.UtcNow
            };

            await _attachmentRepository.AddAsync(attachment);
            return attachment;
        }
    }
}
