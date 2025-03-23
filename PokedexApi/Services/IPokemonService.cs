using PokedexApi.Models;
using PokedexApi.Dtos;

namespace PokedexApi.Services
{
        public interface IPokemonService
    {
        Task<Pokemon?> GetPokemonByIdAsync(Guid id, CancellationToken cancellationToken);

        Task<IEnumerable<PokemonResponse>> GetPokemonByNameAsync(string name, CancellationToken cancellationToken);

        Task<bool>DeletePokemonByIdAsync(Guid id, CancellationToken cancellationToken);
    }
}
