using System.Runtime.Serialization;

namespace PokemonApi.Dtos;

[DataContract(Name = "StatsDto", Namespace = "http://pokemon-api/pokemon-service")]
public class StatsDto
{
    [DataMember(Name = "attack", Order = 1)]
    public int Attack { get; set; }

    [DataMember(Name = "desense", Order = 2)]
    public int Desense { get; set; }

    [DataMember(Name = "speed", Order = 3)]
    public int Speed { get; set; }
}