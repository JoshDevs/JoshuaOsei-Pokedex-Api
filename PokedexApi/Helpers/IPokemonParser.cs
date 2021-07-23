using PokedexApi.Dto;
using PokedexApi.Models;

namespace PokedexApi.Helpers
{
    public interface IPokemonParser
    {
        /// <summary>
        /// Helper method to Parse the PokeApi response.
        /// </summary>
        /// <param name="pokemonSpecies"></param>
        /// <returns>An object of <see cref="Pokemon"/>.</returns>
        Pokemon ParsePokemon(PokemonSpecies pokemonSpecies);
    }
}