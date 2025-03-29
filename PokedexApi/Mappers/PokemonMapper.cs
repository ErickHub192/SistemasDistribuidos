using PokedexApi.Dtos;
using PokedexApi.Models;
using PokedexApi.Infrastructure.Soap.Dtos;

namespace PokedexApi.Mapper
{
    public static class PokemonMapper
    {
        public static PokemonResponse ToDto(this Pokemon pokemon)
        {
            if (pokemon == null)
                throw new ArgumentNullException(nameof(pokemon), "El objeto Pokemon es nulo.");

            return new PokemonResponse
            {
                Id = pokemon.Id,
                Name = pokemon.Name ?? "Desconocido",
                Type = pokemon.Type ?? "Desconocido",
                Level = pokemon.Level,
                PowerLevel = pokemon.PowerLevel,
                Stats = new StatsResponse
                {
                    Attack = pokemon.Stats?.Attack ?? 0,
                    Desense = pokemon.Stats?.Defense ?? 0,
                    Speed = pokemon.Stats?.Speed ?? 0
                }
            };
        }

        
        public static Pokemon ToModel(this PokemonResponseDto pokemon)
        {
            if (pokemon == null)
                throw new ArgumentNullException(nameof(pokemon), "El objeto PokemonResponseDto es nulo.");

            Console.WriteLine($"[DEBUG] Mapeando DTO a modelo: {pokemon.Name ?? "Nombre nulo"}");

            return new Pokemon
            {
                Id = pokemon.Id,
                Name = pokemon.Name ?? "Desconocido",
                Type = pokemon.Type ?? "Desconocido",
                Level = pokemon.Level,
                PowerLevel = pokemon.PowerLevel,
                Stats = new Stats
                {
                    Attack = pokemon.Stats?.Attack ?? 0,
                    Defense = pokemon.Stats?.Desense ?? 0,
                    Speed = pokemon.Stats?.Speed ?? 0
                }
            };
        }

        public static CreatePokemonDto ToSoapDto(this Pokemon pokemon)
        {
            return new CreatePokemonDto
            {
                Name = pokemon.Name,
                Type = pokemon.Type,
                Level = pokemon.Level,
                PowerLevel = pokemon.PowerLevel,
                Stats = new StatsDto
                {
                    Attack = pokemon.Stats?.Attack ?? 0,
                    Desense = pokemon.Stats?.Defense ?? 0,
                    Speed = pokemon.Stats?.Speed ?? 0
                }
            };
        }

        public static Pokemon ToModel(this CreatePokemonRequest pokemon)
        {
            return new Pokemon
            {
                Name = pokemon.Name,
                Type = pokemon.Type,
                Level = pokemon.Level,
                PowerLevel = pokemon.PowerLevel,
                Stats = new Stats
                {
                    Attack = pokemon.Attack,
                    Defense = pokemon.Desense,
                    Speed = pokemon.Speed
                }
            };
        }

        public static Pokemon ToModel(this UpdatePokemonRequest pokemon)
        {
            return new Pokemon
            {
                Name = pokemon.Name,
                Type = pokemon.Type,
                Level = pokemon.Level,
                PowerLevel = pokemon.PowerLevel,
                Stats = new Stats
                {
                    Attack = pokemon.Attack,
                    Defense = pokemon.Desense,
                    Speed = pokemon.Speed
                }
            };
        }
        public static UpdatePokemonDto ToUpdateSoapDto(this Pokemon pokemon)
        {
            return new UpdatePokemonDto
            {
                Id = pokemon.Id,
                Name = pokemon.Type, 
                Type = pokemon.Type, 
                Level = pokemon.Level,
                PowerLevel = pokemon.PowerLevel,
                Stats = new StatsDto
                {
                    Attack = pokemon.Stats.Attack,
                    Desense = pokemon.Stats.Defense,
                    Speed = pokemon.Stats.Speed
                }
            };
        }
    }
}


