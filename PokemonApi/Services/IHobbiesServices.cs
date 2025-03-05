using System.ServiceModel;
using PokemonApi.Dtos;

namespace PokemonApi.Services;

[ServiceContract(Name = "HobbiesService", Namespace = "http://hobbiesapi/hobbies-service")]
public interface IHobbiesService
{
    [OperationContract]
    Task<HobbiesResponseDto> GetById(Guid id, CancellationToken cancellationToken);

        [OperationContract]
        Task<HobbiesResponseDto> DeleteHobby(Guid id, CancellationToken cancellationToken);

        [OperationContract]
        Task<List<HobbiesResponseDto>> GetByName(string name, CancellationToken cancellationToken);

        [OperationContract]
        Task<HobbiesResponseDto> CreateHobby(CreateHobbyDto createHobbyDto,CancellationToken cancellationToken);

        [OperationContract]
        Task<HobbiesResponseDto> UpdateHobby(UpdateHobbyDto hobby,CancellationToken cancellationToken);

}