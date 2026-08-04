using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.MODELS.DOMAIN;
using NZWalks.API.MODELS.DTOs;
using NZWalks.API.Repositories;

namespace NZwalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenRepository tokenRepository;

        public AuthController(ITokenRepository tokenRepository)
        {
            this.tokenRepository = tokenRepository;
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var users = new List<User>
            {
                new User
                {
                    Id = Guid.NewGuid(),
                    Username = "reader@nzwalks.com",
                    Password = "Reader@123",
                    Roles = new List<string> { "Reader" }
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    Username = "writer@nzwalks.com",
                    Password = "Writer@123",
                    Roles = new List<string> { "Writer" }
                }
            };

            var user = users.FirstOrDefault(x =>
                x.Username.Equals(loginRequestDto.Username, StringComparison.OrdinalIgnoreCase)
                && x.Password == loginRequestDto.Password);

            if (user == null)
            {
                return Unauthorized();
            }

            var jwtToken = tokenRepository.CreateJWTToken(user);

            var response = new LoginResponseDto
            {
                JwtToken = jwtToken
            };

            return Ok(response);
        }
    }
}