namespace PokedexApi.Repositories
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Configuration;
    using Newtonsoft.Json;
    using PokedexApi.Dto;

    /// <summary>
    /// Class to obtain data of Pokemon.
    /// </summary>
    public class PokemonRepository : IPokemonRepository
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="PokemonRepository"/> class.
        /// </summary>
        /// <param name="httpClient">An instance of <see cref="HttpClient"/>.</param>
        /// <param name="configuration">An instance of <see cref="IConfiguration"/>.</param>
        public PokemonRepository(HttpClient httpClient, IConfiguration configuration)
        {
            this.httpClient = httpClient;
            this.configuration = configuration;
        }

        /// <inheritdoc/>
        public async Task<PokemonSpecies> GetPokemonSpecies(string pokemon)
        {
            string uri = $"{this.configuration["PokemonConfig:PokeApiUrl"]}pokemon-species/{pokemon}";
            HttpResponseMessage response = await httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();

            var data = JsonConvert.DeserializeObject<PokemonSpecies>(await response.Content.ReadAsStringAsync());

            return data;
        }
    }
}
