using HeroesApi.Contexts;
using HeroesApi.Models;
using Microsoft.EntityFrameworkCore;
using Models.Contracts;

namespace Models.DataRepository;
public class HeroRepository(HeroContext context) : IDataRepository
{
    readonly HeroContext _heroContext = context;

    public async Task AddAsync(Hero entity)
    {
        _heroContext.Heroes.Add(entity);
        await _heroContext.SaveChangesAsync();
    }

    public async Task<Hero?> GetAsync(long id) => await _heroContext.Heroes.FindAsync(id);

    public async Task UpdateAsync(Hero entityToUpdate, Hero entity)
    {
        entityToUpdate.Name = entity.Name;
        entityToUpdate.Description = entity.Description;

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