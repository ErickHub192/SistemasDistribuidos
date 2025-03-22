namespace PokedexApi.Models;

public class Pokemon {
 public Guid Id {get; set;}

  public required string   Name {get; set;}

  public required string  Type {get; set;}
  public required int Level {get; set;}

public required int PowerLevel {get; set;}

public required Stats Stats {set; get;}
}