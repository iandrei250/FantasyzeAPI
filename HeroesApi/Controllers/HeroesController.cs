using HeroesApi.Models;
using HeroesApi.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Models.Contracts;

namespace HeroesApi.Controllers;

[ApiController]
[Route("api/heroes")]
public class HeroesController(IDataRepository dataRepository) : ControllerBase
{
    private readonly IDataRepository _dataRepository = dataRepository;

    [HttpGet]
    public async Task<IActionResult> GetAllheros()
    {
        var heroes = await _dataRepository.GetAllAsync();

        return Ok(heroes);
    }

    [HttpGet("{id}", Name = "GetHero")]
    public async Task<IActionResult> Gethero(long id)
    {
        var hero = await _dataRepository.GetAsync(id);
        if (hero is null)
        {
            return NotFound("hero not found.");
        }

        return Ok(hero);
    }

    [HttpPost]
    public async Task<IActionResult> PostHero([FromBody] HeroDTO hero)
    {
        if (hero is null)
        {
            return BadRequest("hero is null.");
        }
        await _dataRepository.AddAsync(hero);

        return CreatedAtRoute("GetHero", new { hero.Id }, null);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutHero(int id, [FromBody] HeroDTO hero){
        if (hero is null)
        {
            return BadRequest("hero is null.");
        }

        var heroToUpdate = await _dataRepository.GetAsync(id);
        if (heroToUpdate is null)
        {
            return NotFound("The hero record couldn't be found.");
        }
        await _dataRepository.UpdateAsync(heroToUpdate, hero);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteHero(int id)
    {
        var hero = await _dataRepository.GetAsync(id);
        if (hero is null)
        {
            return NotFound("The hero record couldn't be found.");
        }
        await _dataRepository.DeleteAsync(hero);

        return NoContent();
    }
}
