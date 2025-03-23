using System.ServiceModel;
using PokemonApi.Dtos;
using PokemonApi.Mappers;
using PokemonApi.Repositories;
using PokemonApi.Validators;

namespace PokemonApi.Services;


public class PokemonService : IPokemonService
{
    private readonly IPokemonRepository _pokemonRepository;
    public PokemonService(IPokemonRepository pokemonRepository){
        _pokemonRepository = pokemonRepository;
    }
    public async Task<PokemonResponseDto> GetPokemonByIdAsync(Guid id, CancellationToken cancellationToken){
        var pokemon = await _pokemonRepository.GetPokemonByIdAsync(id,cancellationToken);
        if (pokemon is null){
            throw new FaultException("Pokemon not found :(");
        }
        return pokemon.ToDto();
        

    }

  public async Task<bool> DeletePokemonByIdAsync(Guid id, CancellationToken cancellationToken){
        var pokemon = await _pokemonRepository.GetPokemonByIdAsync(id,cancellationToken);
        if(pokemon is null)
{
    throw new FaultException("Pokemon not found :(");
}   
    await _pokemonRepository.DeletePokemonByIdAsync(pokemon, cancellationToken);
    return true;
    }
    public async Task<PokemonResponseDto[]> GetPokemonByNameAsync(string name, CancellationToken cancellationToken)
{
    var pokemons = await _pokemonRepository.GetPokemonByNameAsync(name, cancellationToken);

    
    if (pokemons is null || !pokemons.Any())
    {
       
        return Array.Empty<PokemonResponseDto>();
    }

    
    return pokemons.Select(p => p.ToDto()).ToArray();
}


    public async Task<PokemonResponseDto>CreatePokemon(CreatePokemonDto pokemon,CancellationToken cancellationToken){
        var pokemonToCreate=pokemon.ToModel();

        pokemonToCreate.ValidateName().ValidateLevel().ValidateType();
        await _pokemonRepository.AddAsync(pokemonToCreate, cancellationToken);
        return pokemonToCreate.ToDto();
    }

     public async Task<PokemonResponseDto> UpdatePokemon(UpdatePokemonDto pokemon,CancellationToken cancellationToken){

        var pokemonToUpdate=await _pokemonRepository.GetPokemonByIdAsync(pokemon.Id,cancellationToken);

        if(pokemonToUpdate is null){
            throw new FaultException("Pokemon not found :(");
        }

        pokemonToUpdate.Name=pokemon.Name;
        pokemonToUpdate.Type=pokemon.Type;
        pokemonToUpdate.Level=pokemon.Level;
        pokemonToUpdate.PowerLevel=pokemon.PowerLevel;
        pokemonToUpdate.Stats.Attack=pokemon.Stats.Attack;
        pokemonToUpdate.Stats.Desense=pokemon.Stats.Desense;
        pokemonToUpdate.Stats.Speed=pokemon.Stats.Speed;

        await _pokemonRepository.UpdateAsync(pokemonToUpdate,cancellationToken);
        return pokemonToUpdate.ToDto();
     

    }
}