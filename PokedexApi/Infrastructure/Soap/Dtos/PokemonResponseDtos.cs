using System.Runtime.Serialization;
using PokedexApi.Dtos;
namespace PokedexApi.Infrastructure.Soap.Dtos
{

     [DataContract(Name = "PokemonResponseDto", Namespace = "http://Pokemon-api/Pokemon-service")]
   
    public class PokemonResponseDto
    {
         [DataMember(Name = "Id", Order = 1)]
        public Guid Id { get; set; }

         [DataMember(Name = "Name", Order = 2)]
        public required string Name { get; set; }
        
         [DataMember(Name = "Type", Order = 3)]
        public required string Type { get; set; }
        
         [DataMember(Name = "Level", Order = 4)]
        public int Level { get; set; }
        
        
 [DataMember(Name = "PowerLevel", Order = 5)]
        public int PowerLevel {get; set;}
        
         [DataMember(Name = "Stats", Order = 6)]
        public required StatsDto Stats { get; set; }
    }
}
