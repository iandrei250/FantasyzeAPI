namespace HeroesApi.Models;

public class Hero
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public byte[] Image { get; set; } = null!;
}