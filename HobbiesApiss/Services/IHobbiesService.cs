using System.ServiceModel;
using HobbiesApi.Infrastructure.Soap.Dtos;

namespace HobbiesApi.Services;

[ServiceContract(Name = "HobbiesService", Namespace = "http://hobbiesapi/hobbies-service")]
public interface IHobbiesService
{
    [OperationContract]
    Task<HobbiesResponseDto> GetHobbyById(Guid id, CancellationToken cancellationToken);

    [OperationContract]
    Task<List<HobbiesResponseDto>> GetHobbyByName(string name, CancellationToken cancellationToken);
}
