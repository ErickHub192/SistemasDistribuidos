using System.ServiceModel;
using PokemonApi.Dtos;
using PokemonApi.Mappers;
using PokemonApi.Repositories;

namespace PokemonApi.Services;


public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    public BookService(IBookRepository bookRepository){
        _bookRepository = bookRepository;
    }
    public async Task<BookResponseDto> GetBookById(Guid id, CancellationToken cancellationToken){
        var book = await _bookRepository.GetByAsync(id,cancellationToken);
        if (book is null){
            throw new FaultException("book not found");
        }
        return book.ToDto();
        

    }
}