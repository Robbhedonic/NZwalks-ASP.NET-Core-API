using NZWalks.API.MODELS.DOMAIN;

namespace NZWalks.API.Repositories
{
    public interface IWalkRepository
    {
        Task<List<Walks>> GetAllAsync();
        Task<Walks> CreateAsync(Walks walk);
    }
}