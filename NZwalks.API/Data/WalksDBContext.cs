using Microsoft.EntityFrameworkCore;
using NZWalks.API.MODELS.DOMAIN;

namespace NZWalks.API.DATA
{
    public class NZWalksDBContext : DbContext
    {
        public NZWalksDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walks> Walks { get; set; }
    }
}