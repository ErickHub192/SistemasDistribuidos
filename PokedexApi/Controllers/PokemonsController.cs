using PokedexApi.Services;
using PokedexApi.Dtos;
using PokedexApi.Mapper;
using Microsoft.AspNetCore.Mvc;
namespace PokedexApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class PokemonsController : ControllerBase
{
    private readonly IPokemonService _pokemonService;

    public PokemonsController(IPokemonService pokemonService){
        _pokemonService = pokemonService;
    }
    //localhost/api/v1/pokemons/{id}
[HttpGet("{id}")]

public async Task<ActionResult<PokemonResponse>> GetPokemonById(Guid id, CancellationToken cancellationToken)

{

 var pokemon = await _pokemonService.GetPokemonByIdAsync(id, cancellationToken);
 if (pokemon is null){
    return NotFound();
 }
 return Ok(pokemon.ToDto());
}

[HttpGet]
public async Task<ActionResult<IEnumerable<PokemonResponse>>> GetPokemonByName([FromQuery] string name, CancellationToken cancellationToken)
{
    if (string.IsNullOrWhiteSpace(name))
    {
        return BadRequest("El parámetro 'name' es requerido.");
    }

    
    var pokemons = await _pokemonService.GetPokemonByNameAsync(name, cancellationToken);

    
    return Ok(pokemons);
}

[HttpDelete("{id}")]

public async Task<ActionResult> DeletePokemonById(Guid id, CancellationToken cancellationtoken){
    var deleted = await _pokemonService.DeletePokemonByIdAsync(id, cancellationtoken);
    if(deleted){
        return NoContent();
    }
    return NotFound();
}
}