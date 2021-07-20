using System.Threading.Tasks;
using PokedexApi.Models;

namespace PokedexApi.Services
{
    /// <summary>
    /// Interface of the <see cref="PokemonService"/> class.
    /// </summary>
    public interface IPokemonService
    {
        /// <summary>
        /// Gets the data of Pokemon.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>An object of <see cref="Pokemon"/>.</returns>
        Task<Pokemon> GetPokemonData(string name);
    }
}