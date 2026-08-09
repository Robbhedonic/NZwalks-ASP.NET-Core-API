using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NZwalks.API.CustomActionFilters;
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
        private readonly IMapper mapper;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        // GET: https://localhost:xxxx/api/regions
        [HttpGet]
        [Authorize(Roles = "Reader")]
        [ProducesResponseType(typeof(List<RegionDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var regions = await regionRepository.GetAllAsync();
            var regionsDto = mapper.Map<List<RegionDto>>(regions);

            return Ok(regionsDto);
        }

        // GET: https://localhost:xxxx/api/regions/{id}
        [HttpGet("{id:Guid}")]
        [Authorize(Roles = "Reader")]
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

            var regionDto = mapper.Map<RegionDto>(region);

            return Ok(regionDto);
        }

        // POST: https://localhost:xxxx/api/regions
        [HttpPost]
        [Authorize(Roles = "Writer")]
        [ValidateModel]
        [ProducesResponseType(typeof(RegionDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            var region = mapper.Map<Region>(addRegionRequestDto);
            region.Id = Guid.NewGuid();

            region = await regionRepository.CreateAsync(region);

            var regionDto = mapper.Map<RegionDto>(region);

            return CreatedAtAction(nameof(GetById), new { id = region.Id }, regionDto);
        }
        // PUT: https://localhost:xxxx/api/regions/{id}
        [HttpPut("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        [ValidateModel]
        [ProducesResponseType(typeof(RegionDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            var regionDomainModel = mapper.Map<Region>(updateRegionRequestDto);

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

            var regionDto = mapper.Map<RegionDto>(region);

            return Ok(regionDto);
        }

        // DELETE: https://localhost:xxxx/api/regions/{id}
        [HttpDelete("{id:Guid}")]
        [Authorize(Roles = "Reader,Writer")]
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

            var regionDto = mapper.Map<RegionDto>(region);

            return Ok(regionDto);
        }
        
    }
}