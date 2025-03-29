using PokedexApi.Models;
using PokedexApi.Repositories;
using PokedexApi.Dtos;
using PokedexApi.Mapper;
using PokedexApi.Exceptions;
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
    public async Task<Pokemon> CreatePokemonAsync(Pokemon pokemon, CancellationToken cancellationToken){
        return await _pokemonRepository.CreatePokemonAsync(pokemon, cancellationToken);
    }
    public async Task UpdatePokemonAsync(Guid id, Pokemon pokemon, CancellationToken cancellationToken){
        var pokemons = await _pokemonRepository.GetPokemonByNameAsync(pokemon.Name, cancellationToken);
        if (pokemons.Any(s => s.Name.ToLower() == pokemon.Name.ToLower() && s.Id != id)){
            throw new PokemonConflictException(message: "pokemom already exist");
        }

        if(pokemon.Level <=0){
            throw new PokemonValidationException("Level must be greater than 0");
        }
        pokemon.Id = id;

        await _pokemonRepository.UpdatePokemonAsync(pokemon, cancellationToken);
    }
}