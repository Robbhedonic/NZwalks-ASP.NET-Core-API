using Microsoft.AspNetCore.Mvc;
using NZWalks.API.MODELS.DOMAIN;
using NZWalks.API.MODELS.DTOs;
using NZWalks.API.Repositories;

namespace NZwalks.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepository regionRepository;

        public RegionsController(IRegionRepository regionRepository)
        {
            this.regionRepository = regionRepository;
        }

        // GET: https://localhost:xxxx/api/regions
        [HttpGet]
        [ProducesResponseType(typeof(List<RegionDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var regions = await regionRepository.GetAllAsync();
            var regionsDto = regions.Select(region => new RegionDto
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name,
                RegionImageUrl = region.RegionImageUrl
            }).ToList();

            return Ok(regionsDto);
        }

        // GET: https://localhost:xxxx/api/regions/{id}
        [HttpGet("{id:Guid}")]
        [ProducesResponseType(typeof(RegionDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var region = await regionRepository.GetByIdAsync(id);

            if (region == null)
            {
                var problemDetails = new ProblemDetails
                {
                    Title = "Region not found",
                    Detail = $"No region was found for ID '{id}'.",
                    Status = StatusCodes.Status404NotFound,
                    Type = "https://httpstatuses.com/404"
                };

                return NotFound(problemDetails);
            }

            var regionDto = new RegionDto
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name,
                RegionImageUrl = region.RegionImageUrl
            };

            return Ok(regionDto);
        }

        // POST: https://localhost:xxxx/api/regions
        [HttpPost]
        [ProducesResponseType(typeof(RegionDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            if (addRegionRequestDto == null)
            {
                return BadRequest();
            }

            if (string.IsNullOrWhiteSpace(addRegionRequestDto.Code) || string.IsNullOrWhiteSpace(addRegionRequestDto.Name))
            {
                return ValidationProblem(new ValidationProblemDetails
                {
                    Title = "Invalid region",
                    Detail = "Code and Name are required."
                });
            }

            var region = new Region
            {
                Id = Guid.NewGuid(),
                Code = addRegionRequestDto.Code,
                Name = addRegionRequestDto.Name,
                RegionImageUrl = addRegionRequestDto.RegionImageUrl
            };

            region = await regionRepository.CreateAsync(region);

            var regionDto = new RegionDto
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name,
                RegionImageUrl = region.RegionImageUrl
            };

            return CreatedAtAction(nameof(GetById), new { id = region.Id }, regionDto);
        }
        // PUT: https://localhost:xxxx/api/regions/{id}
        [HttpPut("{id:Guid}")]
        [ProducesResponseType(typeof(RegionDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            if (updateRegionRequestDto == null)
            {
                return BadRequest();
            }

            var regionDomainModel = new Region
            {
                Code = updateRegionRequestDto.Code,
                Name = updateRegionRequestDto.Name,
                RegionImageUrl = updateRegionRequestDto.RegionImageUrl
            };

            var region = await regionRepository.UpdateAsync(id, regionDomainModel);

            if (region == null)
            {
                var problemDetails = new ProblemDetails
                {
                    Title = "Region not found",
                    Detail = $"No region was found for ID '{id}'.",
                    Status = StatusCodes.Status404NotFound,
                    Type = "https://httpstatuses.com/404"
                };

                return NotFound(problemDetails);
            }

            var regionDto = new RegionDto
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name,
                RegionImageUrl = region.RegionImageUrl
            };

            return Ok(regionDto);
        }

        // DELETE: https://localhost:xxxx/api/regions/{id}
        [HttpDelete("{id:Guid}")]
        [ProducesResponseType(typeof(RegionDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var region = await regionRepository.DeleteAsync(id);

            if (region == null)
            {
                var problemDetails = new ProblemDetails
                {
                    Title = "Region not found",
                    Detail = $"No region was found for ID '{id}'.",
                    Status = StatusCodes.Status404NotFound,
                    Type = "https://httpstatuses.com/404"
                };

                return NotFound(problemDetails);
            }

            var regionDto = new RegionDto
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name,
                RegionImageUrl = region.RegionImageUrl
            };

            return Ok(regionDto);
        }
        
    }
}