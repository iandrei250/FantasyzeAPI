using HeroesApi.Contexts;
using HeroesApi.Models;
using HeroesApi.Models.Dtos;
using Microsoft.EntityFrameworkCore;
using Models.Contracts;

namespace Models.DataRepository;
public class HeroRepository(HeroContext context) : IDataRepository
{
    readonly HeroContext _heroContext = context;

    public async Task AddAsync(HeroDTO dto)
    {
        byte[] imageData;
        using var ms = new MemoryStream();
        await dto.Image.CopyToAsync(ms);
        imageData = ms.ToArray();

        var hero = new Hero
        {
            Name = dto.Name,
            Description = dto.Description,
            Image = imageData
        };

        _heroContext.Heroes.Add(hero);
        await _heroContext.SaveChangesAsync();
    }

    public async Task<Hero?> GetAsync(long id) => await _heroContext.Heroes.FindAsync(id);

    public async Task UpdateAsync(Hero existing, HeroDTO dto)
    { 
        existing.Name = dto.Name;
        existing.Description = dto.Description;

        if (dto.Image != null)
        {
            using var ms = new MemoryStream();
            await dto.Image.CopyToAsync(ms);
            existing.Image = ms.ToArray();
        }

        await _heroContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(Hero entity)
    {
        _heroContext.Remove(entity);
        await _heroContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Hero>> GetAllAsync()
    {
        return await _heroContext.Heroes.ToListAsync<Hero>();
    }
}