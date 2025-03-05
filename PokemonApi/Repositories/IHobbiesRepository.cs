using PokemonApi.Models;
namespace PokemonApi.Repositories;


public interface IHobbiesRepository{
    Task<Hobbies> GetHobbyById(Guid id, CancellationToken cancellationToken);
    Task<Hobbies> DeleteHobby(Guid id, CancellationToken cancellationToken);
      Task<List<Hobbies>> GetHobbiesByName(string name, CancellationToken cancellationToken);

       Task AddAsync(Hobbies hobbies,CancellationToken cancellationToken);

    Task UpdateAsync(Hobbies hobbies,CancellationToken cancellationToken);
    


}
