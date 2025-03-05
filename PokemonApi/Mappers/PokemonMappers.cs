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
                Stats = new statsDto {
                    Attack  = pokemon.Stats.Attack,
                    Speed   = pokemon.Stats.Speed,
                    Defense = pokemon.Stats.Defense
                }
            };
        }
        public static Pokemon ToModel (this CreatePokemonDto pokemon){
            return new Pokemon{
                Id =Guid.NewGuid(),
                Name = pokemon.Name,
                Type =pokemon.Type,
                Level = pokemon.Level,
                PowerLevel = pokemon.PowerLevel,
                Stats =pokemon.Stats.ToModel()

            };
        }
        public static PokemonEntity ToEntity(this Pokemon pokemon){

    return new PokemonEntity{
        Id=pokemon.Id,
        Name=pokemon.Name,
        Type=pokemon.Type,
        Level=pokemon.Level,
        Attack=pokemon.Stats.Attack,
        Desense=pokemon.Stats.Defense,
        Speed=pokemon.Stats.Speed
    };
}
        public static Stats ToModel(this statsDto stats){
            return new Stats{
                Attack = stats.Attack,
                Defense = stats.Defense,
                Speed = stats.Speed
            };
        }
    }
}
