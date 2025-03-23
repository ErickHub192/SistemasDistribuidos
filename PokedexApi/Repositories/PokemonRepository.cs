using System.ServiceModel;
using PokedexApi.Infrastructure.Soap.Contracts;
using PokedexApi.Models;
using PokedexApi.Mapper;
namespace PokedexApi.Repositories;


public class PokemonRepository : IPokemonRepository{

    private readonly ILogger<PokemonRepository> _logger;
    private readonly IPokemonService _pokemonService;
    

 public  PokemonRepository(ILogger<PokemonRepository>logger, IConfiguration configuration){
    _logger = logger;
 var endpoint = new EndpointAddress(configuration.GetValue<string>("PokemonServiceEndpoint"));
 var binding = new BasicHttpBinding();
 _pokemonService = new ChannelFactory<IPokemonService>(binding, endpoint).CreateChannel();
 }

public async Task<Pokemon?> GetPokemonByIdAsync(Guid id, CancellationToken cancellationToken){

try{
var pokemon = await _pokemonService.GetPokemonByIdAsync(id, cancellationToken);
return pokemon.ToModel();
}catch(FaultException ex ) when(ex.Message == "Pokemon not found :(")
{
_logger.LogError(ex, "Failed to get pokemon with id: {id}", id );

return null;

}
}
public async Task<IEnumerable<Pokemon>> GetPokemonByNameAsync(string name, CancellationToken cancellationToken)
{
    try
    {
        
        var responseDtos = await _pokemonService.GetPokemonByNameAsync(name, cancellationToken);
        
        
        if (responseDtos == null)
            return Enumerable.Empty<Pokemon>();

        return responseDtos.Select(dto => dto.ToModel());
    }
    catch (FaultException ex)
    {
        _logger.LogError(ex, "Error al buscar pokémons con nombre: {name}", name);
        return Enumerable.Empty<Pokemon>();
    }
}

public async Task<bool> DeletePokemonByIdAsync(Guid id, CancellationToken cancellationToken){

    try{
        await _pokemonService.DeletePokemonByIdAsync(id, cancellationToken);
return true;
    }
    
catch(FaultException ex)  when(ex.Message =="Pokemon not found :("){
return false;
}
catch(Exception ex ){

 _logger.LogError(ex, "Failed to delete pokemon with id: {id}",id);
        throw;

}
}

}