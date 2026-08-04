namespace NZWalks.API.MODELS.DTOs
{
    public class UpdateWalkRequestDto
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string LengthInKM { get; set; } = string.Empty;
        public string? WalkImageUrl { get; set; }
        public Guid DifficultyId { get; set; }
        public Guid RegionId { get; set; }
    }
}