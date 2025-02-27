using Microsoft.EntityFrameworkCore;
using PokemonApi.Infrastructure;
using PokemonApi.Mappers;
using PokemonApi.Models;

namespace PokemonApi.Repositories;

public class BookRepository : IBookRepository {

    private readonly RelationalDbContext _context;
public BookRepository(RelationalDbContext context){
    _context = context;
}
public async Task<Book>  GetByAsync(Guid id, CancellationToken cancellationToken){
    
    var Book = await _context.Books.AsNoTracking().FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
    return Book.ToModel();
}
}