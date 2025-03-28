using System.Runtime.Serialization;
namespace HobbiesApi.Infrastructure.Soap.Dtos


{
    [DataContract(Name = "HobbiesService", Namespace = "http://hobbies-api/hobbies-service")]
    public class HobbiesResponseDto
    {
        [DataMember(Name = "Id", Order = 1)]
        public Guid Id { get; set; }

         [DataMember(Name = "Name", Order = 2)]
        public required string Name { get; set; }

         [DataMember(Name = "Top", Order = 3)]
        public required int Top { get; set; }
         
    }
}