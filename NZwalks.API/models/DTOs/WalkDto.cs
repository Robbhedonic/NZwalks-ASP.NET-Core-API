namespace NZWalks.API.MODELS.DTOs
{
    public class WalkDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string LengthInKM { get; set; } = string.Empty;
        public string? WalkImageUrl { get; set; }
        public RegionDto Region { get; set; } = null!;
        public DifficultyDto Difficulty { get; set; } = null!;
    }
}