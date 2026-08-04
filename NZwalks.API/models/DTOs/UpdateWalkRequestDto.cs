using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.MODELS.DTOs
{
    public class UpdateWalkRequestDto
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Name has to be a maximum of 100 characters")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(1000, ErrorMessage = "Description has to be a maximum of 1000 characters")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [RegularExpression(@"^(?:[0-9]|[1-4][0-9]|50)(?:\.\d+)?$", ErrorMessage = "LengthInKM has to be between 0 and 50")]
        public string LengthInKM { get; set; } = string.Empty;

        public string? WalkImageUrl { get; set; }

        [Required]
        public Guid DifficultyId { get; set; }

        [Required]
        public Guid RegionId { get; set; }
    }
}