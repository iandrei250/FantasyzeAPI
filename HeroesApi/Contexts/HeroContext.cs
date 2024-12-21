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
                Description = "Batman is cool"
            },
             new Hero
            {
                Id = 2,
                Name = "Spider-Man",
                Description = "Spider-Man is cool"
            }
        );
    }
}