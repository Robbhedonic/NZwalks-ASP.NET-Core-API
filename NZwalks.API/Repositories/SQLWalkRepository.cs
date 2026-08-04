using Microsoft.EntityFrameworkCore;
using NZWalks.API.DATA;
using NZWalks.API.MODELS.DOMAIN;

namespace NZWalks.API.Repositories
{
    public class SQLWalkRepository : IWalkRepository
    {
        private readonly NZWalksDBContext dbContext;

        public SQLWalkRepository(NZWalksDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Walks>> GetAllAsync()
        {
            return await dbContext.Walks
                .Include("Difficulty")
                .Include("Region")
                .ToListAsync();
        }

        public async Task<Walks?> GetByIdAsync(Guid id)
        {
            return await dbContext.Walks
                .Include("Difficulty")
                .Include("Region")
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Walks> CreateAsync(Walks walk)
        {
            await dbContext.Walks.AddAsync(walk);
            await dbContext.SaveChangesAsync();

            return walk;
        }
    }
}