using PokedexApi.Services;
using PokedexApi.Dtos;
using PokedexApi.Mapper;
using Microsoft.AspNetCore.Mvc;
using PokedexApi.Exceptions;
using System.Linq.Expressions;

namespace PokedexApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class PokemonsController : ControllerBase
{
    private readonly IPokemonService _pokemonService;

    public PokemonsController(IPokemonService pokemonService)
    {
        _pokemonService = pokemonService;
    }
    
    // GET: localhost/api/v1/pokemons/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<PokemonResponse>> GetPokemonById(Guid id, CancellationToken cancellationToken)
    {
        var pokemon = await _pokemonService.GetPokemonByIdAsync(id, cancellationToken);
        if (pokemon is null)
        {
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
    public async Task<ActionResult> DeletePokemonById(Guid id, CancellationToken cancellationToken)
    {
        var deleted = await _pokemonService.DeletePokemonByIdAsync(id, cancellationToken);
        if (deleted)
        {
            return NoContent();
        }
        return NotFound();
    }

   [HttpPost]
public async Task<ActionResult<PokemonResponse>> CreatePokemonRequest(
    [FromBody] CreatePokemonRequest pokemon, CancellationToken cancellationToken)
{
    if (pokemon == null)
    {
        return BadRequest(new { message = "Invalid request data." });
    }

    try
    {
        var createdPokemon = await _pokemonService.CreatePokemonAsync(pokemon.ToModel(), cancellationToken);
        
        return CreatedAtAction(nameof(GetPokemonById), new { id = createdPokemon.Id }, createdPokemon.ToDto());
    }
    catch (PokemonConflictException ex)
    {
    
        return Conflict(new { message = ex.Message });
    }
    catch (PokemonValidationException ex)
    {
        return BadRequest(new { message = ex.Message });
    }
    catch (Exception ex)
    {
        return StatusCode(500, new { message = "An unexpected error occurred.", error = ex.Message });
    }
}

[HttpPut("{id}")]

public async Task<IActionResult> UpdatePokemon(Guid id,[FromBody]UpdatePokemonRequest pokemon, CancellationToken cancellationToken){
    try{
await _pokemonService.UpdatePokemonAsync(id, pokemon.ToModel(), cancellationToken);
return NoContent();
    }catch(PokemonConflictException ){
return Conflict(new{message = $"Pokemon already exist"});
    }catch(PokemonValidationException ex){
        return BadRequest(new{message = ex.Message});
    }catch(PokemonNotFoundException){
return NotFound(new { message = "Pokémon no encontrado" });
    }
}
}



