using Microsoft.EntityFrameworkCore;
using PokemonApi.Infrastructure;
using PokemonApi.Mappers;
using PokemonApi.Models;

namespace PokemonApi.Repositories;

public class HobbiesRepository : IHobbiesRepository {

    private readonly RelationalDbContext _context;
public HobbiesRepository(RelationalDbContext context){
    _context = context;
}
public async Task<Hobbies> GetHobbyById(Guid id, CancellationToken cancellationToken){
    
    var hobbies = await _context.Hobbies.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
    return hobbies.ToModel();
}
 public async Task<Hobbies> DeleteHobby(Guid id, CancellationToken cancellationToken)
    {
        var hobbyEntity = await _context.Hobbies
            .FirstOrDefaultAsync(h => h.Id == id, cancellationToken);

        if (hobbyEntity == null)
            return null;

        _context.Hobbies.Remove(hobbyEntity);
        await _context.SaveChangesAsync(cancellationToken);

        return hobbyEntity.ToModel();
    }
    public async Task<List<Hobbies>> GetHobbiesByName(string name, CancellationToken cancellationToken)
    {
        var hobbyEntities = await _context.Hobbies
            .AsNoTracking()
            .Where(h => EF.Functions.Like(h.Name, $"%{name}%"))
            .ToListAsync(cancellationToken);
            
        return hobbyEntities.Select(h => h.ToModel()).ToList();
    }
}