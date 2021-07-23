using System.Threading.Tasks;
using PokedexApi.Dto;

namespace PokedexApi.Repositories
{
    /// <summary>
    /// Interface of the <see cref="PokemonRepository"/> class.
    /// </summary>
    public interface IPokemonRepository
    {
        /// <summary>
        /// Method to get the data of a Pokemon.
        /// </summary>
        /// <param name="pokemon"></param>
        /// <returns>The <see cref="PokemonSpecies"/> object.</returns>
        Task<PokemonSpecies> GetPokemonSpecies(string pokemon);

        /// <summary>
        /// Method to get the translated data of a Pokemon.
        /// </summary>
        /// <param name="description">The non-translated description of a Pokemon.</param>
        /// <param name="language">The translation language.</param>
        /// <returns>The <see cref="TranslationResponse"/> object.</returns>
        Task<TranslationResponse> GetTranslation(string description, string language);
    }
}