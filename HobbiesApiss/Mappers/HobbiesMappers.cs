using HobbiesApi.Dtos;
using HobbiesApi.Models;
using HobbiesApi.Infrastructure.Soap.Dtos;

namespace HobbiesApi.Mappers;

    public static class HobbiesMapper
    {
        public static HobbiesResponseDto ToDto(this Hobbies hobbies)
        {
            return new HobbiesResponseDto
            {
                Id = hobbies.Id,
                Name = hobbies.Name,
                Top = hobbies.Top
                
                 
            };
        }
    

        public static Hobbies ToModel(this HobbiesResponseDto hobbies)
        {
            return new Hobbies
            {
                Id = hobbies.Id,
                Name = hobbies.Name,
                Top = hobbies.Top
                
            };
        }
    }