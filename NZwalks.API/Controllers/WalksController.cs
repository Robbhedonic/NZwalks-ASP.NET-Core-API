using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
        [ProducesResponseType(typeof(WalkDto), StatusCodes.Status200OK)]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            var walkDomainModel = mapper.Map<Walks>(addWalkRequestDto);
            walkDomainModel.Id = Guid.NewGuid();

            walkDomainModel = await walkRepository.CreateAsync(walkDomainModel);

            return Ok(mapper.Map<WalkDto>(walkDomainModel));
        }
    }
}