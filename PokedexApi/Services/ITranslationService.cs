using System.Threading.Tasks;
using PokedexApi.Models;

namespace PokedexApi.Services
{
    /// <summary>
    /// The interface of the <see cref="TranslationService"/> class.
    /// </summary>
    public interface ITranslationService
    {
        /// <summary>
        ///  Method to get the translated Pokemon.
        /// </summary>
        /// <param name="pokemon"></param>
        /// <returns>The translated description of the Pokemon.</returns>
        Task<string> GetTranslation(Pokemon pokemon);
    }
}