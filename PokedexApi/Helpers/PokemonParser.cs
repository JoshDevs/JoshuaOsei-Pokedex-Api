namespace PokedexApi.Helpers
{
    using System.Linq;
    using PokedexApi.Dto;
    using PokedexApi.Models;

    /// <summary>
    /// Helper class to parse the data from the PokeApi.
    /// </summary>
    public class PokemonParser : IPokemonParser
    {
        /// <inheritdoc />
        public Pokemon ParsePokemon(PokemonSpecies pokemonSpecies)
        {
            var data = new Pokemon()
            {
                Name = pokemonSpecies.Name,
                Description = pokemonSpecies.Description.FirstOrDefault(x => x.DescriptionLanguage.Language == "en").DescriptionText,
                Habitat = pokemonSpecies.Habitat.Name,
                IsLegendary = pokemonSpecies.isLegendary,
            };

            return data;
        }
    }
}
