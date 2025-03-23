using System.ServiceModel;
using PokemonApi.Dtos;
using PokemonApi.Mappers;
using PokemonApi.Repositories;
using PokemonApi.Validators;
namespace PokemonApi.Services;


public class HobbiesService : IHobbiesService
{
    private readonly IHobbiesRepository _hobbiesRepository;
    public HobbiesService(IHobbiesRepository hobbiesRepository){
        _hobbiesRepository = hobbiesRepository;
    }
    public async Task<HobbiesResponseDto> GetById(Guid id, CancellationToken cancellationToken){
        var hobbies = await _hobbiesRepository.GetHobbyById(id,cancellationToken);
        if (hobbies is null){
            throw new FaultException("Hobby not found");
        }
        return hobbies.ToDto();
        

    }
     public async Task<HobbiesResponseDto> DeleteHobby(Guid id, CancellationToken cancellationToken)
        {
            var hobby = await _hobbiesRepository.DeleteHobby(id, cancellationToken);
            if (hobby is null)
            {
                throw new FaultException("Hobby not found");
            }

            return hobby.ToDto();
        }
         public async Task<List<HobbiesResponseDto>> GetByName(string name, CancellationToken cancellationToken)
{
    var hobbies = await _hobbiesRepository.GetHobbiesByName(name, cancellationToken);

    if (hobbies == null || !hobbies.Any())
    {
        return new List<HobbiesResponseDto>();
    }

    return hobbies.Select(h => h.ToDto()).ToList();
}

  public async Task<HobbiesResponseDto>CreateHobby(CreateHobbyDto hobbies,CancellationToken cancellationToken){
        var hobbyToCreate=hobbies.ToModel();

        hobbyToCreate.ValidateName().ValidateTop();
        await _hobbiesRepository.AddAsync(hobbyToCreate, cancellationToken);
        return hobbyToCreate.ToDto();
    }

     public async Task<HobbiesResponseDto> UpdateHobby(UpdateHobbyDto hobbies,CancellationToken cancellationToken){

        var hobbyToUpdate=await _hobbiesRepository.GetHobbyById(hobbies.Id,cancellationToken);

        if(hobbyToUpdate is null){
            throw new FaultException("hobby not found");
        }

        hobbyToUpdate.Name=hobbies.Name;
        hobbyToUpdate.Top= hobbies.Top;

        await _hobbiesRepository.UpdateAsync(hobbyToUpdate,cancellationToken);
        return hobbyToUpdate.ToDto();
     

    }
}