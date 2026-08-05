using Microsoft.EntityFrameworkCore;
using NZWalks.API.MODELS.DOMAIN;

namespace NZWalks.API.DATA
{
    public class NZWalksDBContext : DbContext
    {
        public NZWalksDBContext(DbContextOptions<NZWalksDBContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walks> Walks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for difficulties
            var difficulties = new List<Difficulty>
            {
                new Difficulty
                {
                    Id = Guid.Parse("6E9D5AB1-E4A1-4A7D-8F0A-74A2BFA6C101"),
                    Name = "Easy"
                },
                new Difficulty
                {
                    Id = Guid.Parse("2C6E41B0-8B7D-4FDF-8DFB-8A4C5EE3D102"),
                    Name = "Medium"
                },
                new Difficulty
                {
                    Id = Guid.Parse("F3A7C868-2D66-45A0-A6C7-26C8BE20A103"),
                    Name = "Hard"
                }
            };

            modelBuilder.Entity<Difficulty>().HasData(difficulties);

            // Seed data for regions
            var regions = new List<Region>
            {
                new Region
                {
                    Id = Guid.Parse("E0E19E8D-9CA6-4E64-93D8-4AAFA1BF9101"),
                    Name = "Auckland",
                    Code = "AKL",
                    RegionImageUrl = "https://images.unsplash.com/photo-1507699622108-4be3abd695ad"
                },
                new Region
                {
                    Id = Guid.Parse("F9DA6C03-AD3E-4B53-AF7E-4AE0C7D59102"),
                    Name = "Northland",
                    Code = "NTL",
                    RegionImageUrl = "https://images.unsplash.com/photo-1469474968028-56623f02e42e"
                },
                new Region
                {
                    Id = Guid.Parse("A6F7B710-81B1-47FC-8665-9C715FBF9103"),
                    Name = "Waikato",
                    Code = "WKO",
                    RegionImageUrl = "https://images.unsplash.com/photo-1472396961693-142e6e269027"
                },
                new Region
                {
                    Id = Guid.Parse("8C1FBEA1-8B9D-43E9-8A0F-B8D7411C9104"),
                    Name = "Bay of Plenty",
                    Code = "BOP",
                    RegionImageUrl = "https://images.unsplash.com/photo-1516298773066-c48f8e9bd92b"
                },
                new Region
                {
                    Id = Guid.Parse("0D0F1A74-D457-4F55-9C5C-4C0EE28C9105"),
                    Name = "Wellington",
                    Code = "WGN",
                    RegionImageUrl = "https://images.unsplash.com/photo-1470770841072-f978cf4d019e"
                },
                new Region
                {
                    Id = Guid.Parse("B23D4F8C-785A-4F19-A6F5-915EA2BC9106"),
                    Name = "Canterbury",
                    Code = "CAN",
                    RegionImageUrl = "https://images.unsplash.com/photo-1441974231531-c6227db76b6e"
                }
            };

            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}