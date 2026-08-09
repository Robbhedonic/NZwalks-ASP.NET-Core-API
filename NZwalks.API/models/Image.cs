using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace NZWalks.API.MODELS.DOMAIN
{
    public class Image
    {
        public Guid Id { get; set; }

        [NotMapped]
        public IFormFile? File { get; set; }

        public string FileName { get; set; } = string.Empty;
        public string? FileDescription { get; set; }
        public string FileExtension { get; set; } = string.Empty;
        public long FileSizeInBytes { get; set; }
        public string FilePath { get; set; } = string.Empty;
    }
}
