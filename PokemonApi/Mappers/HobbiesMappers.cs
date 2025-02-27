using PokemonApi.Dtos;
using PokemonApi.Infrastructure.Entities;
using PokemonApi.Models;

namespace PokemonApi.Mappers
{
    public static class HobbiesMapper
    {
        public static Hobbies ToModel(this HobbiesEntity entity)
        {
            if (entity is null)
            {
                return null;
            }

            return new Hobbies {
                Id   = entity.Id,
                Name = entity.Name,
                Top = entity.Top
                };
        }

        public static HobbiesResponseDto ToDto(this Hobbies hobbies)
        {
            if (hobbies is null)
            {
                return null;
            }

            return new HobbiesResponseDto {
                Id    = hobbies.Id,
                Name = hobbies.Name,
                Top  = hobbies.Top
            };
        }
    }
}
