using Microsoft.EntityFrameworkCore;
using PokemonApi.Infrastructure;
using PokemonApi.Mappers;
using PokemonApi.Models;

namespace PokemonApi.Repositories;

public class PokemonRepository : IPokemonRepository {

    private readonly RelationalDbContext _context;
public PokemonRepository(RelationalDbContext context){
    _context = context;
}
public async Task<Pokemon> GetByAsync(Guid id, CancellationToken cancellationToken){
    
    var Pokemon = await _context.Pokemons.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
    return Pokemon.ToModel();
}
}