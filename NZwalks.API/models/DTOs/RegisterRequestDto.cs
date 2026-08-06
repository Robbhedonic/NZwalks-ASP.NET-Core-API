using System.ComponentModel.DataAnnotations;

namespace NZWalks.API.MODELS.DTOs
{
    public class RegisterRequestDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        public string[] Roles { get; set; } = Array.Empty<string>();
    }
}