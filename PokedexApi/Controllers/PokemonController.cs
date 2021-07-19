namespace PokedexApi.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using PokedexApi.Models;

    /// <summary>
    /// The <see cref="PokemonController"/> class.
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class PokemonController : Controller
    {
        /// <summary>
        /// Initializes a new instance of <see cref="PokemonController"/> class.
        /// </summary>
        public PokemonController()
        {

        }

        /// <summary>
        /// Gets the information of a Pokemon.
        /// </summary>
        /// <returns>A instance of <see cref="Pokemon"/>.</returns>
        [HttpGet("name")]
        public async Task<Pokemon> GetPokemon(string name)
        {
            
        }
    }
}
