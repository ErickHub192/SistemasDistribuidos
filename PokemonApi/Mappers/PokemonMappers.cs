using PokemonApi.Dtos;
using PokemonApi.Infrastructure.Entities;
using PokemonApi.Models;

namespace PokemonApi.Mappers
{
    public static class PokemonMapper
    {
        public static Pokemon ToModel(this PokemonEntity entity)
        {
            if (entity is null)
            {
                return null;
            }

            return new Pokemon {
                Id   = entity.Id,
                Name = entity.Name,
                Type = entity.Type,
                Level = entity.Level,
                PowerLevel = entity.PowerLevel,
                Stats = new Stats {
                    Attack  = entity.Attack,
                    Defense = entity.Desense,
                    Speed   = entity.Speed
                }
            };
        }

        public static PokemonResponseDto ToDto(this Pokemon pokemon)
        {
            if (pokemon is null)
            {
                return null;
            }

            return new PokemonResponseDto {
                Id    = pokemon.Id,
                Level = pokemon.Level,
                Name  = pokemon.Name,
                Type  = pokemon.Type,
                PowerLevel  = pokemon.PowerLevel,
                Status = new statsDto {
                    Attack  = pokemon.Stats.Attack,
                    Speed   = pokemon.Stats.Speed,
                    Defense = pokemon.Stats.Defense
                }
            };
        }
    }
}
