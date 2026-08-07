using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.MODELS.DTOs;
using NZWalks.API.Repositories;

namespace NZwalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenRepository tokenRepository;
        private readonly UserManager<IdentityUser> userManager;

        public AuthController(ITokenRepository tokenRepository, UserManager<IdentityUser> userManager)
        {
            this.tokenRepository = tokenRepository;
            this.userManager = userManager;
        }

        [HttpPost]
        [Route("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerRequestDto.Username,
                Email = registerRequestDto.Username
            };

            var identityResult = await userManager.CreateAsync(identityUser, registerRequestDto.Password);

            if (!identityResult.Succeeded)
            {
                return BadRequest("Something went wrong");
            }

            if (registerRequestDto.Roles != null && registerRequestDto.Roles.Any())
            {
                identityResult = await userManager.AddToRolesAsync(identityUser, registerRequestDto.Roles);

                if (!identityResult.Succeeded)
                {
                    return BadRequest("Something went wrong");
                }
            }

            return Ok("User was registered! Please login.");
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var user = await userManager.FindByEmailAsync(loginRequestDto.Username);

            if (user == null)
            {
                return BadRequest("Username or Password incorrect");
            }

            var checkPasswordResult = await userManager.CheckPasswordAsync(user, loginRequestDto.Password);

            if (!checkPasswordResult)
            {
                return BadRequest("Username or Password incorrect");
            }

            var roles = await userManager.GetRolesAsync(user);

            if (roles == null)
            {
                return BadRequest("Username or Password incorrect");
            }

            var jwtToken = tokenRepository.CreateJWTToken(user, roles.ToList());

            var response = new LoginResponseDto
            {
                JwtToken = jwtToken
            };

            return Ok(response);
        }
    }
}