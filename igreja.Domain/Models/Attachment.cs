using igreja.Domain.Models.General;

namespace igreja.Domain.Models
{
    public class Attachment : EntityFull
    {
        public Guid Id { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public byte[] Data { get; set; }
        public DateTime UploadedAt { get; set; }
    }

}
