using System.Runtime.Serialization;
namespace HobbiesApi.Infrastructure.Soap.Dtos;
[DataContract(Name ="UpdateHobbyDto", Namespace="http://hobbies-api/hobbies-service")]
    public class UpdateHobbyDto:HobbiesCommon
    {
    [DataMember(Name="Id",Order =3)]
    public Guid Id { get; set; }
    
    }
