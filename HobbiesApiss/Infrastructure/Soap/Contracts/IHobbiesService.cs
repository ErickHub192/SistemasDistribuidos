using System.ServiceModel;
using HobbiesApi.Infrastructure.Soap.Dtos;

namespace HobbiesApi.Infrastructure.Soap.Contracts;

[ServiceContract(Name = "HobbiesService", Namespace = "http://hobbies-api/hobbies-service")]
public interface IHobbiesService
{
    [OperationContract]
    Task<HobbiesResponseDto> GetById(Guid id, CancellationToken cancellationToken);

        [OperationContract]
        Task<List<HobbiesResponseDto>> GetByName(string name, CancellationToken cancellationToken);

        [OperationContract]
        Task<HobbiesResponseDto> DeleteHobby(Guid id, CancellationToken cancellationToken);


}