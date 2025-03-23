using System.ServiceModel; 
using HobbiesApi.Infrastructure.Soap.Dtos;
using HobbiesApi.Mappers;
using HobbiesApi.Dtos;
using HobbiesApi.Repositories;

namespace HobbiesApi.Services
{
    public class HobbiesService : IHobbiesService
    {
        private readonly IHobbiesRepository _hobbiesRepository;

        public HobbiesService(IHobbiesRepository hobbiesRepository)
        {
            _hobbiesRepository = hobbiesRepository;
        }

        public async Task<HobbiesResponseDto> GetHobbyById(Guid id, CancellationToken cancellationToken)
        {
            var hobbies = await _hobbiesRepository.GetHobbyById(id, cancellationToken);
            if (hobbies is null)
            {
                throw new FaultException("Hobby not found ):");
            }
            return hobbies.ToDto();
        }

        public async Task<List<HobbiesResponseDto>> GetHobbyByName(string name, CancellationToken cancellationToken)
        {
            var hobbies = await _hobbiesRepository.GetHobbiesByName(name, cancellationToken);

            if (hobbies == null || !hobbies.Any())
            {
                return new List<HobbiesResponseDto>();
            }

            return hobbies.Select(h => h.ToDto()).ToList();
        }
    }
}
