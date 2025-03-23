using System.Runtime.Serialization;

namespace PokemonApi.Dtos;

[DataContract(Name = "statsDto", Namespace = "http://pokemon-api/pokemon-service")]
public class statsDto
{
    [DataMember(Name = "attack", Order = 1)]
    public int Attack { get; set; }

    [DataMember(Name = "defense", Order = 2)]
    public int Defense { get; set; }

    [DataMember(Name = "speed", Order = 3)]
    public int Speed { get; set; }
}