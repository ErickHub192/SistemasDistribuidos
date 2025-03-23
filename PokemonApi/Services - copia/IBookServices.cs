using System.ServiceModel;
using PokemonApi.Dtos;

namespace PokemonApi.Services;

[ServiceContract(Name = "BookService", Namespace = "http://bookapi/book-service")]
public interface IBookService
{
    [OperationContract]
    Task<BookResponseDto> GetBookById(Guid id, CancellationToken cancellationToken);
}