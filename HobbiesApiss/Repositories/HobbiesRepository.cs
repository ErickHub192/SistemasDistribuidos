using HobbiesApi.Mappers;
using HobbiesApi.Models;
using System.ServiceModel;


namespace HobbiesApi.Repositories
{
    public class HobbiesRepository : IHobbiesRepository
    {
        private readonly ILogger<HobbiesRepository> _logger;
        private readonly Infrastructure.Soap.Contracts.IHobbiesService _hobbiesService; 

        public HobbiesRepository(ILogger<HobbiesRepository> logger, IConfiguration configuration)
        {
            _logger = logger;
            var endpoint = new EndpointAddress(configuration.GetValue<string>("HobbiesServiceEndpoint"));
            var binding = new BasicHttpBinding();
            _hobbiesService = new ChannelFactory<Infrastructure.Soap.Contracts.IHobbiesService>(binding, endpoint).CreateChannel();
        }

        public async Task<Hobbies?> GetHobbyById(Guid id, CancellationToken cancellationToken)
        {
            try
            {
                var hobbies = await _hobbiesService.GetById(id, cancellationToken);
                return hobbies?.ToModel();
            }
            catch (FaultException ex) when (ex.Message =="Hobby not found ):")
            {
                _logger.LogWarning(ex, "Failed to get Hobby with id {id}", id);
                return null;
            }
        }

        public async Task<List<Hobbies>> GetHobbiesByName(string name, CancellationToken cancellationToken)
        {
            try
            {
                var hobbies = await _hobbiesService.GetByName(name, cancellationToken);
                return hobbies?.Select(h => h.ToModel()).ToList() ?? new List<Hobbies>();
            }
            catch (FaultException ex) when (ex.Message =="Hobby not found ):")
            {
                _logger.LogWarning(ex, "Failed to get hobby with name {name}", name);
                return new List<Hobbies>();
            }
        }

    }
}

