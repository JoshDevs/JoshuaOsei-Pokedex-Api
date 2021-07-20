namespace PokedexApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using PokedexApi.Models;
    using PokedexApi.Services;

    /// <summary>
    /// The <see cref="PokemonController"/> class.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : Controller
    {
        private readonly IPokemonService pokemonService;

        /// <summary>
        /// Initializes a new instance of <see cref="PokemonController"/> class.
        /// </summary>
        /// <param name="pokemonService">An instance of the <see cref="PokemonService"/> class.</param>
        public PokemonController(IPokemonService pokemonService)
        {
            this.pokemonService = pokemonService;
        }

        /// <summary>
        /// Gets the information of a Pokemon.
        /// </summary>
        /// <returns>A instance of <see cref="Pokemon"/>.</returns>
        [HttpGet("name")]
        public async Task<Pokemon> GetPokemon(string name)
        {
            return await this.pokemonService.GetPokemonData(name);
        }
    }
}
