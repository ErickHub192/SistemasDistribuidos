using PokemonApi.Models;
namespace PokemonApi.Repositories;


public interface IPokemonRepository{
    Task<Pokemon> GetByAsync(Guid id, CancellationToken cancellationToken);
}