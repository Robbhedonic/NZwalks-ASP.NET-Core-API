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
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;

        public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
        }

        [HttpGet]
        [Authorize(Policy = "ReadOnly")]
        [ProducesResponseType(typeof(List<WalkDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll(
            [FromQuery] string? filterOn,
            [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy,
            [FromQuery] bool? isAscending)
        {
            var walksDomainModel = await walkRepository.GetAllAsync(
                filterOn,
                filterQuery,
                sortBy,
                isAscending ?? true);

            return Ok(mapper.Map<List<WalkDto>>(walksDomainModel));
        }

        [HttpGet("{id:guid}")]
        [Authorize(Policy = "ReadOnly")]
        [ProducesResponseType(typeof(WalkDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walkDomainModel = await walkRepository.GetByIdAsync(id);

            if (walkDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<WalkDto>(walkDomainModel));
        }

        [HttpPost]
        [Authorize(Policy = "ReadWrite")]
        [ValidateModel]
        [ProducesResponseType(typeof(WalkDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            var walkDomainModel = mapper.Map<Walks>(addWalkRequestDto);
            walkDomainModel.Id = Guid.NewGuid();

            walkDomainModel = await walkRepository.CreateAsync(walkDomainModel);

            return Ok(mapper.Map<WalkDto>(walkDomainModel));
        }

        [HttpPut("{id:guid}")]
        [Authorize(Policy = "ReadWrite")]
        [ValidateModel]
        [ProducesResponseType(typeof(WalkDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateWalkRequestDto updateWalkRequestDto)
        {
            var walkDomainModel = mapper.Map<Walks>(updateWalkRequestDto);

            walkDomainModel = await walkRepository.UpdateAsync(id, walkDomainModel);

            if (walkDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<WalkDto>(walkDomainModel));
        }

        [HttpDelete("{id:guid}")]
        [Authorize(Policy = "ReadWrite")]
        [ProducesResponseType(typeof(WalkDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedWalkDomainModel = await walkRepository.DeleteAsync(id);

            if (deletedWalkDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<WalkDto>(deletedWalkDomainModel));
        }
    }
}