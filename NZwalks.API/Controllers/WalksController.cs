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

        [HttpGet]
        [ProducesResponseType(typeof(List<WalkDto>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var walksDomainModel = await walkRepository.GetAllAsync();
            return Ok(mapper.Map<List<WalkDto>>(walksDomainModel));
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