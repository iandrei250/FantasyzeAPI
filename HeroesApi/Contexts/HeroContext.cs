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
}