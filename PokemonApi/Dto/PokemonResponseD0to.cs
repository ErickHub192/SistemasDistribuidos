namespace PokemonApi.Dtos
{
    public class PokemonResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Level { get; set; }

         public int PowerLevel { get; set; }
         
        public statsDto Stats { get; set; }
    }
}