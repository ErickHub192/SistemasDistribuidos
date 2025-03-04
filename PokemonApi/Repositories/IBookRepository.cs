using PokemonApi.Models;
namespace PokemonApi.Repositories;


public interface IBookRepository{
    Task<Book> GetByAsync(Guid id, CancellationToken cancellationToken);
}