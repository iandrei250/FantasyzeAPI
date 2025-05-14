using HeroesApi.Models;
using HeroesApi.Models.Dtos;

namespace Models.Contracts;
public interface IDataRepository
{
    Task<IEnumerable<Hero>> GetAllAsync();
    Task<Hero?> GetAsync(long id);
    Task AddAsync(HeroDTO entity);
    Task UpdateAsync(Hero entityToUpdate, HeroDTO entity);
    Task DeleteAsync(Hero entity);
}