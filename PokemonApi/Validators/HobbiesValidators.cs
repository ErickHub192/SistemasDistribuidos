using System.ServiceModel;
using PokemonApi.Models;
namespace PokemonApi.Validators;

public static class HobbyValidator{
    public static Hobbies ValidateName(this Hobbies hobbies) =>
    string.IsNullOrEmpty(hobbies.Name) ?
    throw new FaultException("Hobby not valid"): hobbies;

 public static Hobbies ValidateTop(this Hobbies hobbies) =>
    hobbies.Top <=0 ? throw new FaultException("Hobby Top is required") : hobbies;
}
