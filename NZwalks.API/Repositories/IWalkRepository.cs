using NZWalks.API.MODELS.DOMAIN;

namespace NZWalks.API.Repositories
{
    public interface IWalkRepository
    {
        Task<Walks> CreateAsync(Walks walk);
    }
}