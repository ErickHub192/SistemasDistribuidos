using PokedexApi.Infrastructure.Soap.Dtos;
using System.ServiceModel;
namespace PokedexApi.Infrastructure.Soap.Contracts;

[ServiceContract(Name ="PokemonService",Namespace ="http://pokemon-api/pokemon-service")]
public interface IPokemonService
{
    [OperationContract]
    Task<PokemonResponseDto> GetPokemonByIdAsync(Guid id, CancellationToken cancellationToken);

     [OperationContract ]
        Task<bool> DeletePokemonByIdAsync(Guid id, CancellationToken cancellationToken);

        [OperationContract]
        Task<PokemonResponseDto> CreatePokemon(CreatePokemonDto createPokemonDto,CancellationToken cancellationToken);

        [OperationContract]
        Task<PokemonResponseDto> UpdatePokemon(UpdatePokemonDto pokemon,CancellationToken cancellationToken);

        [OperationContract]
Task<PokemonResponseDto[]> GetPokemonByNameAsync(string name, CancellationToken cancellationToken);

}