using HobbiesApi.Models;
namespace HobbiesApi.Repositories;


public interface IHobbiesRepository{
    Task<Hobbies?> GetHobbyById(Guid id, CancellationToken cancellationToken);
      Task<List<Hobbies>> GetHobbiesByName(string name, CancellationToken cancellationToken);
}
