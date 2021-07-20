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

        /// <summary>
        /// Initializes new instance of the <see cref="PokemonService"/> class.
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="pokemonRepository"></param>
        /// <param name="pokemonParser"></param>
        public PokemonService(IPokemonRepository pokemonRepository, IPokemonParser pokemonParser)
        {
            this.pokemonRepository = pokemonRepository;
            this.pokemonParser = pokemonParser;
        }

        public async Task<Pokemon> GetPokemonData(string name)
        {
            // Note: PokeApi only accepts lower case names so will account for capital inputs in this method

            PokemonSpecies response = await this.pokemonRepository.GetPokemonSpecies(name.ToLower());

            var parsed = this.pokemonParser.ParsePokemon(response);

            return parsed;
        }
    }
}
