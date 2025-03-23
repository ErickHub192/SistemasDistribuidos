using PokedexApi.Dtos;
using PokedexApi.Models;
using PokedexApi.Infrastructure.Soap.Dtos;

namespace PokedexApi.Mapper
{
    public static class PokemonMapper
    {
        // Mapea del modelo (dominio) a la respuesta de la API REST
        public static PokemonResponse ToDto(this Pokemon pokemon)
        {
            if (pokemon == null)
            {
                throw new ArgumentNullException(nameof(pokemon), "El objeto Pokemon es nulo.");
            }
            
            return new PokemonResponse
            {
                Id = pokemon.Id,
                Name = pokemon.Name ?? "Desconocido",
                Type = pokemon.Type ?? "Desconocido",
                Level = pokemon.Level,
                PowerLevel = pokemon.PowerLevel,
                Stats = pokemon.Stats != null
                    ? new StatsResponse
                    {
                        Attack = pokemon.Stats.Attack,
                        // Se mapea el valor de Defense del modelo al campo Desense en la respuesta
                        Desense = pokemon.Stats.Defense,
                        Speed = pokemon.Stats.Speed
                    }
                    : new StatsResponse { Attack = 0, Desense = 0, Speed = 0 }
            };
        }

        // Mapea del DTO SOAP a tu modelo (dominio)
        public static Pokemon ToModel(this PokemonResponseDto pokemon)
        {
            if (pokemon == null)
            {
                throw new ArgumentNullException(nameof(pokemon), "El objeto PokemonResponseDto es nulo.");
            }

            Console.WriteLine($"[DEBUG] Mapeando DTO a modelo: {pokemon.Name ?? "Nombre nulo"}");

            return new Pokemon
            {
                Id = pokemon.Id,
                Name = pokemon.Name ?? "Desconocido",
                Type = pokemon.Type ?? "Desconocido",
                Level = pokemon.Level,
                PowerLevel = pokemon.PowerLevel,
                Stats = pokemon.Stats != null
                    ? new Stats
                    {
                        Attack = pokemon.Stats.Attack,
                        // Se mapea el valor de desense del DTO SOAP al campo Defense en el modelo
                        Defense = pokemon.Stats.Desense,
                        Speed = pokemon.Stats.Speed
                    }
                    : new Stats { Attack = 0, Defense = 0, Speed = 0 }
            };
        }
    }
}
