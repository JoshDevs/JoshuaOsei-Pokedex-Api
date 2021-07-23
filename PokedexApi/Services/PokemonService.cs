namespace PokedexApi.Services
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Logging;
    using PokedexApi.Dto;
    using PokedexApi.Helpers;
    using PokedexApi.Models;
    using PokedexApi.Repositories;

    /// <summary>
    /// The <see cref="PokemonService"/> class.
    /// </summary>
    public class PokemonService : IPokemonService
    {
        private readonly IPokemonRepository pokemonRepository;
        private readonly IPokemonParser pokemonParser;
        private readonly ITranslationService translationService;

        /// <summary>
        /// Initializes new instance of the <see cref="PokemonService"/> class.
        /// </summary>
        /// <param name="pokemonRepository"></param>
        /// <param name="pokemonParser"></param>
        public PokemonService(IPokemonRepository pokemonRepository, IPokemonParser pokemonParser, ITranslationService translationService)
        {
            this.pokemonRepository = pokemonRepository;
            this.pokemonParser = pokemonParser;
            this.translationService = translationService;
        }

        /// <inheritdoc/>
        public async Task<Pokemon> GetPokemonData(string name)
        {
            // Note: PokeApi only accepts lower case names so will account for capital inputs in this method

            PokemonSpecies response = await pokemonRepository.GetPokemonSpecies(name.ToLower());

            var parsed = pokemonParser.ParsePokemon(response);

            return parsed;
        }

        /// <inheritdoc/>
        public async Task<Pokemon> GetTranslatedPokemonData(string name)
        {
            PokemonSpecies pokemonSpecies = await pokemonRepository.GetPokemonSpecies(name.ToLower());

            Pokemon pokemon = pokemonParser.ParsePokemon(pokemonSpecies);

            pokemon.Description = await translationService.GetTranslation(pokemon);

            return pokemon;
        }
    }
}
