using Microsoft.EntityFrameworkCore;
using HeroesApi.Models;


namespace HeroesApi.Contexts;

public class HeroContext : DbContext
{
    public HeroContext(DbContextOptions<HeroContext> options)
        : base(options)
    {
    }

    public DbSet<Hero> Heroes { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Hero>().HasData(
            new Hero
            {
                Id = 1,
                Name = "Batman",
                Description = "Batman is cool",
                Image = new byte[] { 0x00, 0x01, 0x02 }
            },
             new Hero
            {
                Id = 2,
                Name = "Spider-Man",
                Description = "Spider-Man is cool",
                Image = new byte[] { 0x00, 0x01, 0x02 }
            }
        );
    }
}