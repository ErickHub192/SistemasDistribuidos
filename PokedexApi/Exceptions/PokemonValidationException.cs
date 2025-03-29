namespace PokedexApi.Exceptions
{
    public class PokemonValidationException : Exception
    {
        public PokemonValidationException(string message) : base(message)
        {
        }
    }

    public class PokemonConflictException : Exception
    {
        public PokemonConflictException(string message) : base(message)
        {
        }
    }
}
