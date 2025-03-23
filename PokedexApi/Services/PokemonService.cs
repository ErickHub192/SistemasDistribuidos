using PokedexApi.Models;
using PokedexApi.Repositories;
using PokedexApi.Dtos;
using PokedexApi.Mapper;
namespace PokedexApi.Services;

public  class PokemonService : IPokemonService {
private readonly IPokemonRepository _pokemonRepository;
    public  PokemonService(IPokemonRepository pokemonRepository){
        _pokemonRepository = pokemonRepository;
    }


    public async Task<Pokemon?> GetPokemonByIdAsync(Guid id, CancellationToken cancellationToken )
    {
        return await _pokemonRepository.GetPokemonByIdAsync(id, cancellationToken);
    }
    public async Task<IEnumerable<PokemonResponse>> GetPokemonByNameAsync(string name, CancellationToken cancellationToken)
    {
        
        var pokemons = await _pokemonRepository.GetPokemonByNameAsync(name, cancellationToken);
        
        return pokemons.Select(p => p.ToDto());
    }

    public async Task<bool> DeletePokemonByIdAsync(Guid id, CancellationToken cancellationToken){
        return await _pokemonRepository.DeletePokemonByIdAsync(id, cancellationToken);
    }
}