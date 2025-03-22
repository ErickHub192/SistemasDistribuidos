using System.Runtime.Serialization;

namespace PokedexApi.Infrastructure.Soap.Dtos;

[DataContract(Name ="PokemonCommon", Namespace="http://pokemon-api/pokemon-service")]
[KnownType(typeof(CreatePokemonDto))]
[KnownType(typeof(UpdatePokemonDto))]
public class PokemonCommon
{
     [DataMember(Name="Name",Order =1)]
    public required string Name { get; set; }
    
    [DataMember(Name="Type",Order=2)]
    public required string Type { get; set; }
    
    [DataMember(Name="Level",Order=3)]
    public int Level { get; set; }

[DataMember(Name="PowerLevel",Order=4)]
    public int PowerLevel {get; set;}
    
    [DataMember(Name="Stats",Order=5)]
    public required StatsDto Stats { get; set; } 

     
}