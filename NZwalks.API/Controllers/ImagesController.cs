using Microsoft.AspNetCore.Mvc;
using NZWalks.API.DATA;
using NZWalks.API.MODELS.DOMAIN;
using NZWalks.API.Repositories;
using System.IO;
using System.ComponentModel.DataAnnotations;

namespace NZwalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository imageRepository;

        public ImagesController(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }

        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> Upload([FromForm] ImageUploadRequestDto request)
        {
            ValidateFileUpload(request);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var imageDomainModel = new Image
            {
                File = request.File,
                FileName = request.FileName,
                FileDescription = request.FileDescription,
                FileExtension = Path.GetExtension(request.File.FileName),
                FileSizeInBytes = request.File.Length
            };

            var uploadedImage = await imageRepository.Upload(imageDomainModel);

            return Ok(uploadedImage);
        }

        private void ValidateFileUpload(ImageUploadRequestDto request)
        {
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };

            if (request.File is null)
            {
                ModelState.AddModelError("file", "Please upload a file.");
                return;
            }

            var extension = Path.GetExtension(request.File.FileName);
            if (!allowedExtensions.Contains(extension.ToLowerInvariant()))
            {
                ModelState.AddModelError("file", "Unsupported file extension.");
            }

            if (request.File.Length > 10 * 1024 * 1024)
            {
                ModelState.AddModelError("file", "File size must be less than 10 MB.");
            }
        }
    }

    public class ImageUploadRequestDto
    {
        [Required]
        public IFormFile? File { get; set; }

        [Required]
        public string FileName { get; set; } = string.Empty;

        public string? FileDescription { get; set; }
    }
}
