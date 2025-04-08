namespace  PokedexApi.Dtos;

public class UpdatePokemonRequest{
    public required string Name{get; set;}

    public required string Type{get; set;}
    public required int  Level{get; set;}

    public required int  PowerLevel{get; set;}

    public required int  Attack{get; set;}

    public required int  Desense{get; set;}

    public required int  Speed{get; set;}
}