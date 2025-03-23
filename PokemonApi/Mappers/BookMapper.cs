using PokemonApi.Dtos;
using PokemonApi.Infrastructure.Entities;
using PokemonApi.Models;

namespace PokemonApi.Mappers
{
    public static class BookMapper
    {
        public static Book ToModel(this BookEntity entity)
        {
            if (entity is null)
            {
                return null;
            }

            return new Book {
                Id   = entity.Id,
                Title = entity.Title,
                Author = entity.Author,
                PublishedDate = entity.PublishedDate
                };
        }

        public static BookResponseDto ToDto(this Book book)
        {
            if (book is null)
            {
                return null;
            }

            return new BookResponseDto {
                Id    = book.Id,
                Title = book.Title,
                Author = book.Author,
                PublishedDate = book.PublishedDate
            };
        }
    }
}
