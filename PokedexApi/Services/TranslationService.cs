namespace PokedexApi.Services
{
    using System;
    using System.Threading.Tasks;
    using PokedexApi.Dto;
    using PokedexApi.Models;
    using PokedexApi.Repositories;

    /// <summary>
    /// The <see cref="TranslationService"/> class.
    /// </summary>
    public class TranslationService : ITranslationService
    {
        private readonly IPokemonRepository pokemonRepository;

        /// <summary>
        /// Initializes a new instance of <see cref="TranslationService"/> class.
        /// </summary>
        public TranslationService(IPokemonRepository pokemonRepository)
        {
            this.pokemonRepository = pokemonRepository;
        }

        /// <inheritdoc/>
        public async Task<string> GetTranslation(Pokemon pokemon)
        {
            if (pokemon.Habitat == "cave" || pokemon.IsLegendary)
            {
                TranslationResponse translationResponse = await pokemonRepository.GetTranslation(pokemon.Description, "yoda");

                return translationResponse.Contents.Translated;
            }

            TranslationResponse response = await pokemonRepository.GetTranslation(pokemon.Description, "shakespeare");

            return response.Contents.Translated;
        }
    }
}
