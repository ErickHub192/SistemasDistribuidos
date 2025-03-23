namespace PokemonApi.Models;

public class Pokemon{

    public Guid Id {set; get;}
    public string Name {set; get;}
    public string Type {set; get;}
    
    public int Level {set; get;}
     public int PowerLevel {set; get;}
    public Stats Stats {set; get;}
    
}