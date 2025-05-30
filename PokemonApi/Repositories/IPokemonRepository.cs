using PokemonApi.Models;
namespace PokemonApi.Repositories;


public interface IPokemonRepository{
    Task<Pokemon> GetPokemonByIdAsync(Guid id, CancellationToken cancellationToken);

    Task DeletePokemonByIdAsync (Pokemon pokemon,CancellationToken cancellationToken);

    Task AddAsync(Pokemon pokemon,CancellationToken cancellationToken);

    Task UpdateAsync(Pokemon pokemon,CancellationToken cancellationToken);

    Task<IEnumerable<Pokemon>> GetPokemonByNameAsync(string name, CancellationToken cancellationToken);
    
}