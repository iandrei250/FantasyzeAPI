using HeroesApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace HeroesApi.Controllers;

[ApiController]
[Route("[controller]")]
public class HeroesController : ControllerBase
{
    private static readonly string[] Heroes = new[]
    {
        "Batman", "Spider-Man", "Superman", "Black-Panther", "Wonder Woman"
    };

    private readonly ILogger<HeroesController> _logger;

    public HeroesController(ILogger<HeroesController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetHeroes")]
    public string[] Get()
    {
        return Heroes.ToArray();
    }
}
