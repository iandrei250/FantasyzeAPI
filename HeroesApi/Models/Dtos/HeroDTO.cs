namespace HeroesApi.Models.Dtos
{
    public class HeroDTO
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
    }
}